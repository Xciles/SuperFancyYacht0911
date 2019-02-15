using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperAwesome.Api.Migrations
{
    public partial class ManyTOMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Projects_ProjectId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_ProjectId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Skill");

            migrationBuilder.CreateTable(
                name: "SkillToProject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillToProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillToProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillToProject_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillToProject_ProjectId",
                table: "SkillToProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillToProject_SkillId",
                table: "SkillToProject",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillToProject");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Skill",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skill_ProjectId",
                table: "Skill",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Projects_ProjectId",
                table: "Skill",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
