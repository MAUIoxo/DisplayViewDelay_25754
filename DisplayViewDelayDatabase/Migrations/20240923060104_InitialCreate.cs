using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisplayViewDelayDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT COLLATE NOCASE", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    Fats = table.Column<double>(type: "REAL", nullable: false),
                    Carbohydrates = table.Column<double>(type: "REAL", nullable: false),
                    Proteins = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SavedMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT COLLATE NOCASE", nullable: false),
                    MacroNutrientRatio_MaxProteins = table.Column<int>(type: "INTEGER", nullable: false),
                    MacroNutrientRatio_MaxCarbohydrates = table.Column<int>(type: "INTEGER", nullable: false),
                    MacroNutrientRatio_MaxFats = table.Column<int>(type: "INTEGER", nullable: false),
                    MacroNutrientRatio_MaxCalories = table.Column<int>(type: "INTEGER", nullable: false),
                    MacroNutrientRatio_OptimalAmountProteins = table.Column<double>(type: "REAL", nullable: false),
                    MacroNutrientRatio_OptimalAmountCarbohydrates = table.Column<double>(type: "REAL", nullable: false),
                    MacroNutrientRatio_OptimalAmountFats = table.Column<double>(type: "REAL", nullable: false),
                    MacroNutrientRatio_OptimalAmountCalories = table.Column<double>(type: "REAL", nullable: false),
                    ModifiedSinceLastSave = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastSavedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedMeals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SavedMealId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodId = table.Column<int>(type: "INTEGER", nullable: false),
                    SortOrderIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Min = table.Column<int>(type: "INTEGER", nullable: false),
                    Max = table.Column<int>(type: "INTEGER", nullable: false),
                    OptimalAmount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodSelections_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodSelections_SavedMeals_SavedMealId",
                        column: x => x.SavedMealId,
                        principalTable: "SavedMeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Name",
                table: "Foods",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodSelections_FoodId",
                table: "FoodSelections",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSelections_SavedMealId",
                table: "FoodSelections",
                column: "SavedMealId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedMeals_Name",
                table: "SavedMeals",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodSelections");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "SavedMeals");
        }
    }
}
