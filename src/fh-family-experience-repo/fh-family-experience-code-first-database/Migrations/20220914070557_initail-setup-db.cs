using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fh_family_experience_code_first_database.Migrations
{
    public partial class initailsetupdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessibilityForDisabilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Accessibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessibilityForDisabilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: true),
                    AmountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eligibilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EligibilityType = table.Column<int>(type: "int", nullable: true),
                    MinimumAge = table.Column<int>(type: "int", nullable: true),
                    MaximumjAge = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eligibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fundings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HolidaySchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    OpensAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosesAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SatrtDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidaySchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProvince = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegularSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekDay = table.Column<int>(type: "int", nullable: true),
                    OpensAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosesAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    Interval = table.Column<int>(type: "int", nullable: true),
                    ByDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ByMonthDay = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Score = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Widget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTaxonomies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTaxonomies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceAtLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HolidayScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegularScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAtLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAtLocations_HolidaySchedule_HolidayScheduleId",
                        column: x => x.HolidayScheduleId,
                        principalTable: "HolidaySchedule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceAtLocations_RegularSchedules_RegularScheduleId",
                        column: x => x.RegularScheduleId,
                        principalTable: "RegularSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Taxononmies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vocabulary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTaxonomyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxononmies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxononmies_ServiceTaxonomies_ServiceTaxonomyId",
                        column: x => x.ServiceTaxonomyId,
                        principalTable: "ServiceTaxonomies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    AccessibilityForDisabilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhysicalAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceAtLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_AccessibilityForDisabilities_AccessibilityForDisabilitiesId",
                        column: x => x.AccessibilityForDisabilitiesId,
                        principalTable: "AccessibilityForDisabilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_PhysicalAddress_PhysicalAddressId",
                        column: x => x.PhysicalAddressId,
                        principalTable: "PhysicalAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Locations_ServiceAtLocations_ServiceAtLocationId",
                        column: x => x.ServiceAtLocationId,
                        principalTable: "ServiceAtLocations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Fees = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accreditations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliverableType = table.Column<int>(type: "int", nullable: true),
                    AssuredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AttendingType = table.Column<int>(type: "int", nullable: true),
                    AttendingAccess = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CostOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EligibilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FundingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HolidayScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegularScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceAtLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceTaxonomyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_CostOptions_CostOptionId",
                        column: x => x.CostOptionId,
                        principalTable: "CostOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Eligibilities_EligibilityId",
                        column: x => x.EligibilityId,
                        principalTable: "Eligibilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Fundings_FundingId",
                        column: x => x.FundingId,
                        principalTable: "Fundings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_HolidaySchedule_HolidayScheduleId",
                        column: x => x.HolidayScheduleId,
                        principalTable: "HolidaySchedule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_RegularSchedules_RegularScheduleId",
                        column: x => x.RegularScheduleId,
                        principalTable: "RegularSchedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_ServiceAreas_ServiceAreaId",
                        column: x => x.ServiceAreaId,
                        principalTable: "ServiceAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_ServiceAtLocations_ServiceAtLocationId",
                        column: x => x.ServiceAtLocationId,
                        principalTable: "ServiceAtLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_ServiceTaxonomies_ServiceTaxonomyId",
                        column: x => x.ServiceTaxonomyId,
                        principalTable: "ServiceTaxonomies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organisations_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organisations_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PhoneId",
                table: "Contacts",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AccessibilityForDisabilitiesId",
                table: "Locations",
                column: "AccessibilityForDisabilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_PhysicalAddressId",
                table: "Locations",
                column: "PhysicalAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ServiceAtLocationId",
                table: "Locations",
                column: "ServiceAtLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_ReviewId",
                table: "Organisations",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_ServiceId",
                table: "Organisations",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAtLocations_HolidayScheduleId",
                table: "ServiceAtLocations",
                column: "HolidayScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAtLocations_RegularScheduleId",
                table: "ServiceAtLocations",
                column: "RegularScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ContactId",
                table: "Services",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CostOptionId",
                table: "Services",
                column: "CostOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_EligibilityId",
                table: "Services",
                column: "EligibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_FundingId",
                table: "Services",
                column: "FundingId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_HolidayScheduleId",
                table: "Services",
                column: "HolidayScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_RegularScheduleId",
                table: "Services",
                column: "RegularScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ReviewId",
                table: "Services",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceAreaId",
                table: "Services",
                column: "ServiceAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceAtLocationId",
                table: "Services",
                column: "ServiceAtLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTaxonomyId",
                table: "Services",
                column: "ServiceTaxonomyId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxononmies_ServiceTaxonomyId",
                table: "Taxononmies",
                column: "ServiceTaxonomyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropTable(
                name: "Taxononmies");

            migrationBuilder.DropTable(
                name: "AccessibilityForDisabilities");

            migrationBuilder.DropTable(
                name: "PhysicalAddress");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CostOptions");

            migrationBuilder.DropTable(
                name: "Eligibilities");

            migrationBuilder.DropTable(
                name: "Fundings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ServiceAreas");

            migrationBuilder.DropTable(
                name: "ServiceAtLocations");

            migrationBuilder.DropTable(
                name: "ServiceTaxonomies");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "HolidaySchedule");

            migrationBuilder.DropTable(
                name: "RegularSchedules");
        }
    }
}
