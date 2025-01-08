using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTriggerToDivision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE OR ALTER TRIGGER CREATE_Division_Paths
					ON [dbo].[Division]
					AFTER INSERT, UPDATE
					AS 
					BEGIN
						DECLARE @PARENT_ID INT = NULL;	
						DECLARE @ID INT;
						DECLARE @PATH NVARCHAR(800) = NULL;
						DECLARE @LEVEL INT = 0;

						SELECT		
							@ID = I.DivisionId,
							@PARENT_ID = I.ParentDivisionId
						FROM inserted AS I;

						IF @PARENT_ID IS NOT NULL
							BEGIN 
								WITH HierarchyUp AS 
								(
									SELECT  
										[AD].[DivisionId] ,
										[AD].[ParentDivisionId] ,
										0 AS Level
									FROM [dbo].[Division] AS [AD]
									WHERE [AD].[DivisionId] = @PARENT_ID

									UNION ALL	

									SELECT  
										[ADF].[DivisionId] ,
										[ADF].[ParentDivisionId] ,
										[HU].[Level] + 1 
									FROM [dbo].[Division] AS [ADF] 
									JOIN HierarchyUp AS [HU] ON [ADF].DivisionId  = [HU].[ParentDivisionId]
								),
								STRING_COUNT AS
								(
									SELECT  
										STRING_AGG(CAST([HU].[DivisionId] AS VARCHAR), '-' ) 
										WITHIN GROUP (ORDER BY [HU].[Level] DESC) AS CombinedIDs,
										COUNT(*) AS TotalRecords
									FROM [HierarchyUp] AS [HU] 
								)
								SELECT 
									@PATH = [SC].[CombinedIDs],
									@LEVEL = [SC].[TotalRecords]
								FROM [STRING_COUNT] AS [SC];
							END;
	
						UPDATE [dbo].[Division]
							SET Division.Level = @LEVEL
						FROM [dbo].[Division] T
						INNER JOIN INSERTED I
						ON T.DivisionId = I.DivisionId;

						UPDATE [dbo].[Division]
							SET Division.ParentsPath = @PATH
						FROM [dbo].[Division] T
						INNER JOIN INSERTED I
						ON T.DivisionId = I.DivisionId;
					END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER CREATE_Division_Paths;");
        }
    }
}
