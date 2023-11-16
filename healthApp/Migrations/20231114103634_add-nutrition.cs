using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthApp.Migrations
{
    public partial class addnutrition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServingSize = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Fiber = table.Column<double>(type: "float", nullable: false),
                    Vitamins = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Minerals = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodID);
                });

            migrationBuilder.CreateTable(
                name: "PatientInfos",
                columns: table => new
                {
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citizenship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Room = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AttendingDoctor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dietitian = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NextOfKin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NextOfKinNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInfos", x => x.PatientInfoID);
                });

            migrationBuilder.CreateTable(
                name: "Antropometry",
                columns: table => new
                {
                    anthroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    height = table.Column<double>(type: "float", nullable: false),
                    currentWeight = table.Column<double>(type: "float", nullable: false),
                    bmi = table.Column<double>(type: "float", nullable: false),
                    usualWeight = table.Column<double>(type: "float", nullable: false),
                    waistCircumference = table.Column<double>(type: "float", nullable: false),
                    hipCircumference = table.Column<double>(type: "float", nullable: false),
                    armCircumference = table.Column<double>(type: "float", nullable: false),
                    calfCircumference = table.Column<double>(type: "float", nullable: false),
                    tricepSkinFold = table.Column<double>(type: "float", nullable: false),
                    subscapularSkinFold = table.Column<double>(type: "float", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antropometry", x => x.anthroID);
                    table.ForeignKey(
                        name: "FK_Antropometry_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Biochemicals",
                columns: table => new
                {
                    BioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmokingFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uricAcid = table.Column<double>(type: "float", nullable: false),
                    cholesterol = table.Column<double>(type: "float", nullable: false),
                    totalProtein = table.Column<double>(type: "float", nullable: false),
                    albumin = table.Column<double>(type: "float", nullable: false),
                    globulin = table.Column<double>(type: "float", nullable: false),
                    amylase = table.Column<double>(type: "float", nullable: false),
                    lipase = table.Column<double>(type: "float", nullable: false),
                    hemoglobin = table.Column<double>(type: "float", nullable: false),
                    sodium = table.Column<double>(type: "float", nullable: false),
                    potassium = table.Column<double>(type: "float", nullable: false),
                    calcium = table.Column<double>(type: "float", nullable: false),
                    magnesium = table.Column<double>(type: "float", nullable: false),
                    ammonia = table.Column<double>(type: "float", nullable: false),
                    bleedingTime = table.Column<double>(type: "float", nullable: false),
                    clottingTime = table.Column<double>(type: "float", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biochemicals", x => x.BioID);
                    table.ForeignKey(
                        name: "FK_Biochemicals_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DietaryInfo",
                columns: table => new
                {
                    DietaryInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakfastFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreakfastMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreakfastAmount = table.Column<double>(type: "float", nullable: false),
                    BreakfastTotalCalories = table.Column<double>(type: "float", nullable: false),
                    AMSnackFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMSnackMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMSnackAmount = table.Column<double>(type: "float", nullable: false),
                    AMSnacktotalclories = table.Column<double>(type: "float", nullable: false),
                    LunchFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LunchMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LunchAmount = table.Column<double>(type: "float", nullable: false),
                    LunchTotalCalories = table.Column<double>(type: "float", nullable: false),
                    PMSnackFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMSnackMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMSnackAmout = table.Column<double>(type: "float", nullable: false),
                    PMSnackTotalCalories = table.Column<double>(type: "float", nullable: false),
                    DinnerFood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DinnerMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DinnerAmount = table.Column<double>(type: "float", nullable: false),
                    DinnerTotalCalories = table.Column<double>(type: "float", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryInfo", x => x.DietaryInfoID);
                    table.ForeignKey(
                        name: "FK_DietaryInfo_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyHistory",
                columns: table => new
                {
                    FamilyHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardiovascularDisease = table.Column<bool>(type: "bit", nullable: false),
                    NeuromuscularDisease = table.Column<bool>(type: "bit", nullable: false),
                    GastrointestinalDisease = table.Column<bool>(type: "bit", nullable: false),
                    KidneyDisease = table.Column<bool>(type: "bit", nullable: false),
                    EndocrineDisease = table.Column<bool>(type: "bit", nullable: false),
                    DiabetesMellitusType1 = table.Column<bool>(type: "bit", nullable: false),
                    DiabetesMellitusType2 = table.Column<bool>(type: "bit", nullable: false),
                    PulmonaryDisease = table.Column<bool>(type: "bit", nullable: false),
                    Cancer = table.Column<bool>(type: "bit", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyHistory", x => x.FamilyHistoryID);
                    table.ForeignKey(
                        name: "FK_FamilyHistory_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodExchange",
                columns: table => new
                {
                    FoodExchangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietDiscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breakfast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMSnack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lunch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMSnack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DinnerSupper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodExchange", x => x.FoodExchangeID);
                    table.ForeignKey(
                        name: "FK_FoodExchange_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MacroNutrients",
                columns: table => new
                {
                    MacroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Factor = table.Column<double>(type: "float", nullable: false),
                    TeriLbw = table.Column<double>(type: "float", nullable: false),
                    TeriAbw = table.Column<double>(type: "float", nullable: false),
                    TeriCbw = table.Column<double>(type: "float", nullable: false),
                    KCal = table.Column<int>(type: "int", nullable: false),
                    ChongKg = table.Column<double>(type: "float", nullable: false),
                    Cho = table.Column<double>(type: "float", nullable: false),
                    Chon = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacroNutrients", x => x.MacroID);
                    table.ForeignKey(
                        name: "FK_MacroNutrients_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalH",
                columns: table => new
                {
                    MedicalHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PastIllness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentIllness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodAllergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalH", x => x.MedicalHistoryID);
                    table.ForeignKey(
                        name: "FK_MedicalH_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screening",
                columns: table => new
                {
                    ScreeningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtremeBMI = table.Column<double>(type: "float", nullable: false),
                    WeightLoss = table.Column<double>(type: "float", nullable: false),
                    ReducedIntake = table.Column<double>(type: "float", nullable: false),
                    SevereIllness = table.Column<double>(type: "float", nullable: false),
                    RiskScore = table.Column<int>(type: "int", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screening", x => x.ScreeningId);
                    table.ForeignKey(
                        name: "FK_Screening_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID");
                });

            migrationBuilder.CreateTable(
                name: "Screening2",
                columns: table => new
                {
                    ScreeningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtremeBMI = table.Column<double>(type: "float", nullable: false),
                    WeightLoss = table.Column<double>(type: "float", nullable: false),
                    ReducedIntake = table.Column<double>(type: "float", nullable: false),
                    SevereIllness = table.Column<double>(type: "float", nullable: false),
                    RiskScore = table.Column<int>(type: "int", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screening2", x => x.ScreeningId);
                    table.ForeignKey(
                        name: "FK_Screening2_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID");
                });

            migrationBuilder.CreateTable(
                name: "SGA",
                columns: table => new
                {
                    SgaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightLoss = table.Column<double>(type: "float", nullable: false),
                    FoodIntake = table.Column<int>(type: "int", nullable: false),
                    GastrointestinalSymptom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionalCapacity = table.Column<int>(type: "int", nullable: false),
                    NutritionalRequirementDisease = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalExam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdemaPresence = table.Column<bool>(type: "bit", nullable: false),
                    AlbuminSGA = table.Column<double>(type: "float", nullable: false),
                    BMI = table.Column<double>(type: "float", nullable: false),
                    TIC = table.Column<int>(type: "int", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SGA", x => x.SgaID);
                    table.ForeignKey(
                        name: "FK_SGA_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialHistory",
                columns: table => new
                {
                    SocialHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmokingFrequency = table.Column<int>(type: "int", nullable: false),
                    AlcoholType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlcoholFrequency = table.Column<int>(type: "int", nullable: false),
                    AlcoholQuantity = table.Column<int>(type: "int", nullable: false),
                    PhysActivity = table.Column<int>(type: "int", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialHistory", x => x.SocialHistoryID);
                    table.ForeignKey(
                        name: "FK_SocialHistory_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Antropometry_PatientInfoID",
                table: "Antropometry",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Biochemicals_PatientInfoID",
                table: "Biochemicals",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DietaryInfo_PatientInfoID",
                table: "DietaryInfo",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyHistory_PatientInfoID",
                table: "FamilyHistory",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodExchange_PatientInfoID",
                table: "FoodExchange",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MacroNutrients_PatientInfoID",
                table: "MacroNutrients",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalH_PatientInfoID",
                table: "MedicalH",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Screening_PatientInfoID",
                table: "Screening",
                column: "PatientInfoID",
                unique: true,
                filter: "[PatientInfoID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Screening2_PatientInfoID",
                table: "Screening2",
                column: "PatientInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_SGA_PatientInfoID",
                table: "SGA",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialHistory_PatientInfoID",
                table: "SocialHistory",
                column: "PatientInfoID",
                unique: true,
                filter: "[PatientInfoID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antropometry");

            migrationBuilder.DropTable(
                name: "Biochemicals");

            migrationBuilder.DropTable(
                name: "DietaryInfo");

            migrationBuilder.DropTable(
                name: "FamilyHistory");

            migrationBuilder.DropTable(
                name: "FoodExchange");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "MacroNutrients");

            migrationBuilder.DropTable(
                name: "MedicalH");

            migrationBuilder.DropTable(
                name: "Screening");

            migrationBuilder.DropTable(
                name: "Screening2");

            migrationBuilder.DropTable(
                name: "SGA");

            migrationBuilder.DropTable(
                name: "SocialHistory");

            migrationBuilder.DropTable(
                name: "PatientInfos");
        }
    }
}
