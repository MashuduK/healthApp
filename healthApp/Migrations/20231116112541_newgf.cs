using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthApp.Migrations
{
    public partial class newgf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmbulanceDrivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmbulanceDrivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Announcements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnouncementFor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Complain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplainDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContraceptionGuideRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContraceptionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Effectiveness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SideEffects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraceptionGuideRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContraceptionReminders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextReminderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReminderID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReminderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContraceptionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraceptionReminders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilityTrackerRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CycleLength = table.Column<int>(type: "int", nullable: false),
                    OvulationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FertilityWindowStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FertilityWindowEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilityTrackerRecords", x => x.Id);
                });

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
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
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
                name: "Ambulances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmbulanceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmbulanceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmbulanceDriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ambulances_AmbulanceDrivers_AmbulanceDriverId",
                        column: x => x.AmbulanceDriverId,
                        principalTable: "AmbulanceDrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenstrualCycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenstrualCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenstrualCycles_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorSpecialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientAge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalTest1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalTest2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalTest3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalTest4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medicine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morning1 = table.Column<bool>(type: "bit", nullable: false),
                    Afternoon1 = table.Column<bool>(type: "bit", nullable: false),
                    Evening1 = table.Column<bool>(type: "bit", nullable: false),
                    Medicine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morning2 = table.Column<bool>(type: "bit", nullable: false),
                    Afternoon2 = table.Column<bool>(type: "bit", nullable: false),
                    Evening2 = table.Column<bool>(type: "bit", nullable: false),
                    Medicine3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morning3 = table.Column<bool>(type: "bit", nullable: false),
                    Afternoon3 = table.Column<bool>(type: "bit", nullable: false),
                    Evening3 = table.Column<bool>(type: "bit", nullable: false),
                    Medicine4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morning4 = table.Column<bool>(type: "bit", nullable: false),
                    Afternoon4 = table.Column<bool>(type: "bit", nullable: false),
                    Evening4 = table.Column<bool>(type: "bit", nullable: false),
                    Medicine5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morning5 = table.Column<bool>(type: "bit", nullable: false),
                    Afternoon5 = table.Column<bool>(type: "bit", nullable: false),
                    Evening5 = table.Column<bool>(type: "bit", nullable: false),
                    Medicine6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morning6 = table.Column<bool>(type: "bit", nullable: false),
                    Afternoon6 = table.Column<bool>(type: "bit", nullable: false),
                    Evening6 = table.Column<bool>(type: "bit", nullable: false),
                    Medicine7 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Morning7 = table.Column<bool>(type: "bit", nullable: false),
                    Afternoon7 = table.Column<bool>(type: "bit", nullable: false),
                    Evening7 = table.Column<bool>(type: "bit", nullable: false),
                    CheckUpAfterDays = table.Column<int>(type: "int", nullable: false),
                    PrescriptionAddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorTiming = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AvailableStartDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableEndDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimePerPatient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ambulances_AmbulanceDriverId",
                table: "Ambulances",
                column: "AmbulanceDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Antropometry_PatientInfoID",
                table: "Antropometry",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Doctors_ApplicationUserId",
                table: "Doctors",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

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
                name: "IX_MenstrualCycles_ApplicationUserId",
                table: "MenstrualCycles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ApplicationUserId",
                table: "Patients",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DoctorId",
                table: "Schedules",
                column: "DoctorId");

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
                name: "Ambulances");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Antropometry");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Biochemicals");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "ContraceptionGuideRecords");

            migrationBuilder.DropTable(
                name: "ContraceptionReminders");

            migrationBuilder.DropTable(
                name: "DietaryInfo");

            migrationBuilder.DropTable(
                name: "FamilyHistory");

            migrationBuilder.DropTable(
                name: "FertilityTrackerRecords");

            migrationBuilder.DropTable(
                name: "FoodExchange");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "MacroNutrients");

            migrationBuilder.DropTable(
                name: "MedicalH");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "MenstrualCycles");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Screening");

            migrationBuilder.DropTable(
                name: "Screening2");

            migrationBuilder.DropTable(
                name: "SGA");

            migrationBuilder.DropTable(
                name: "SocialHistory");

            migrationBuilder.DropTable(
                name: "AmbulanceDrivers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "PatientInfos");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
