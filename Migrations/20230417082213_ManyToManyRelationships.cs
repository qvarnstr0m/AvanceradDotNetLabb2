using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvanceradDotNetLabb2.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_StudentCoursesId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teachers_StudentTeacherId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Courses_CourseId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_CourseId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "StudentTeacherId",
                table: "Students",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "StudentCoursesId",
                table: "Students",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentTeacherId",
                table: "Students",
                newName: "IX_Students_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentCoursesId",
                table: "Students",
                newName: "IX_Students_CourseId");

            migrationBuilder.CreateTable(
                name: "CourseSubject",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubject", x => new { x.CoursesId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_CourseSubject_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubject_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    SubjectsId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_SubjectsId",
                table: "CourseSubject",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeachersId",
                table: "SubjectTeacher",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teachers_TeacherId",
                table: "Students",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teachers_TeacherId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "CourseSubject");

            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Students",
                newName: "StudentTeacherId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Students",
                newName: "StudentCoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                newName: "IX_Students_StudentTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                newName: "IX_Students_StudentCoursesId");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CourseId",
                table: "Subjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_StudentCoursesId",
                table: "Students",
                column: "StudentCoursesId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teachers_StudentTeacherId",
                table: "Students",
                column: "StudentTeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Courses_CourseId",
                table: "Subjects",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                table: "Subjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
