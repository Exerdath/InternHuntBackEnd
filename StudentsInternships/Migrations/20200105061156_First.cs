using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsInternships.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    TechnologyId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Interest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.TechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CompanyDescription = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Internships",
                columns: table => new
                {
                    InternshipId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InternshipName = table.Column<string>(nullable: true),
                    InternshipDescription = table.Column<string>(nullable: true),
                    CompanyUserId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internships", x => x.InternshipId);
                    table.ForeignKey(
                        name: "FK_Internships_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Internships_Users_CompanyUserId",
                        column: x => x.CompanyUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentTechnologies",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    TechnologyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTechnologies", x => new { x.StudentId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_StudentTechnologies_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTechnologies_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentUserId = table.Column<int>(nullable: true),
                    InternshipId = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Internships_InternshipId",
                        column: x => x.InternshipId,
                        principalTable: "Internships",
                        principalColumn: "InternshipId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InternshipTechnologies",
                columns: table => new
                {
                    InternshipId = table.Column<int>(nullable: false),
                    TechnologyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipTechnologies", x => new { x.InternshipId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_InternshipTechnologies_Internships_InternshipId",
                        column: x => x.InternshipId,
                        principalTable: "Internships",
                        principalColumn: "InternshipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipTechnologies_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cvs",
                columns: table => new
                {
                    CvId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileLocation = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cvs", x => x.CvId);
                    table.ForeignKey(
                        name: "FK_Cvs_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cvs_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 1, "Cluj" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 2, "Brasov" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 3, "Bucuresti" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "Interest" },
                values: new object[] { 1, ".Net" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "Interest" },
                values: new object[] { 2, "React" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "Interest" },
                values: new object[] { 3, "Java" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "Interest" },
                values: new object[] { 4, "Javascript" });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "Interest" },
                values: new object[] { 5, "Python" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Discriminator", "Password", "Username", "CompanyDescription" },
                values: new object[] { 6, "Company", "microsoft", "Microsoft", "Microsoft company" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Discriminator", "Password", "Username", "CompanyDescription" },
                values: new object[] { 7, "Company", "apple", "Apple", "Apple company" });

            migrationBuilder.InsertData(
                table: "Internships",
                columns: new[] { "InternshipId", "CityId", "CompanyUserId", "InternshipDescription", "InternshipName" },
                values: new object[] { 1, 1, null, "Microsoft 1 Internship", "M1 Internship" });

            migrationBuilder.InsertData(
                table: "Internships",
                columns: new[] { "InternshipId", "CityId", "CompanyUserId", "InternshipDescription", "InternshipName" },
                values: new object[] { 4, 1, null, "Apple 2 Internship", "A2 Internship" });

            migrationBuilder.InsertData(
                table: "Internships",
                columns: new[] { "InternshipId", "CityId", "CompanyUserId", "InternshipDescription", "InternshipName" },
                values: new object[] { 2, 2, null, "Microsoft 2 Internship", "M2 Internship" });

            migrationBuilder.InsertData(
                table: "Internships",
                columns: new[] { "InternshipId", "CityId", "CompanyUserId", "InternshipDescription", "InternshipName" },
                values: new object[] { 3, 3, null, "Apple 1 Internship", "A1 Internship" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Discriminator", "Password", "Username", "CityId" },
                values: new object[] { 1, "Student", "ent", "Stud", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Discriminator", "Password", "Username", "CityId" },
                values: new object[] { 2, "Student", "dent", "Stu", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Discriminator", "Password", "Username", "CityId" },
                values: new object[] { 3, "Student", "udent", "St", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Discriminator", "Password", "Username", "CityId" },
                values: new object[] { 4, "Student", "tudent", "S", 3 });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationId", "InternshipId", "Status", "StudentUserId" },
                values: new object[] { 1, 1, null, 1 });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationId", "InternshipId", "Status", "StudentUserId" },
                values: new object[] { 2, 2, null, 1 });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "ApplicationId", "InternshipId", "Status", "StudentUserId" },
                values: new object[] { 3, 3, null, 2 });

            migrationBuilder.InsertData(
                table: "InternshipTechnologies",
                columns: new[] { "InternshipId", "TechnologyId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "InternshipTechnologies",
                columns: new[] { "InternshipId", "TechnologyId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "InternshipTechnologies",
                columns: new[] { "InternshipId", "TechnologyId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "InternshipTechnologies",
                columns: new[] { "InternshipId", "TechnologyId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "StudentTechnologies",
                columns: new[] { "StudentId", "TechnologyId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "StudentTechnologies",
                columns: new[] { "StudentId", "TechnologyId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "StudentTechnologies",
                columns: new[] { "StudentId", "TechnologyId" },
                values: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "StudentTechnologies",
                columns: new[] { "StudentId", "TechnologyId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "Cvs",
                columns: new[] { "CvId", "ApplicationId", "FileLocation", "StudentId" },
                values: new object[] { 1, 1, "Not important now", 1 });

            migrationBuilder.InsertData(
                table: "Cvs",
                columns: new[] { "CvId", "ApplicationId", "FileLocation", "StudentId" },
                values: new object[] { 2, 2, "Still not important now", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_InternshipId",
                table: "Applications",
                column: "InternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_StudentUserId",
                table: "Applications",
                column: "StudentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cvs_ApplicationId",
                table: "Cvs",
                column: "ApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cvs_StudentId",
                table: "Cvs",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Internships_CityId",
                table: "Internships",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_CompanyUserId",
                table: "Internships",
                column: "CompanyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipTechnologies_TechnologyId",
                table: "InternshipTechnologies",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTechnologies_TechnologyId",
                table: "StudentTechnologies",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cvs");

            migrationBuilder.DropTable(
                name: "InternshipTechnologies");

            migrationBuilder.DropTable(
                name: "StudentTechnologies");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "Internships");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
