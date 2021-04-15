using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CpApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    StationNumber = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.StationNumber);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Birthday = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Nationaly = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SeatsToNextStop = table.Column<int>(nullable: false),
                    StopTime = table.Column<string>(nullable: false),
                    CurrentStationId = table.Column<int>(nullable: false),
                    NextStationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stop_Station_CurrentStationId",
                        column: x => x.CurrentStationId,
                        principalTable: "Station",
                        principalColumn: "StationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stop_Station_NextStationId",
                        column: x => x.NextStationId,
                        principalTable: "Station",
                        principalColumn: "StationNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinalTime = table.Column<string>(nullable: false),
                    InitialTime = table.Column<string>(nullable: false),
                    InitialStationId = table.Column<int>(nullable: false),
                    FinalStationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trip_Station_FinalStationId",
                        column: x => x.FinalStationId,
                        principalTable: "Station",
                        principalColumn: "StationNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trip_Station_InitialStationId",
                        column: x => x.InitialStationId,
                        principalTable: "Station",
                        principalColumn: "StationNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Validity = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCard_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Used = table.Column<bool>(nullable: false),
                    InspectorId = table.Column<int>(nullable: true),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_User_ClientId",
                        column: x => x.ClientId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_User_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    StopId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Stop_StopId",
                        column: x => x.StopId,
                        principalTable: "Stop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_UserId",
                table: "CreditCard",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_StopId",
                table: "Seat",
                column: "StopId");

            migrationBuilder.CreateIndex(
                name: "IX_Stop_CurrentStationId",
                table: "Stop",
                column: "CurrentStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stop_NextStationId",
                table: "Stop",
                column: "NextStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ClientId",
                table: "Ticket",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_InspectorId",
                table: "Ticket",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_FinalStationId",
                table: "Trip",
                column: "FinalStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_InitialStationId",
                table: "Trip",
                column: "InitialStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Stop");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Station");
        }
    }
}
