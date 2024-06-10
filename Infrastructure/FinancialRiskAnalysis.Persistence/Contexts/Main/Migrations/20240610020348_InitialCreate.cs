using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinancialRiskAnalysis.Persistence.Contexts.Main.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessContract",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessContract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessTopic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessTopic_BusinessContract_BusinessContractId",
                        column: x => x.BusinessContractId,
                        principalTable: "BusinessContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessTopic_Partner_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartnerContract",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerContract_BusinessContract_BusinessContractId",
                        column: x => x.BusinessContractId,
                        principalTable: "BusinessContract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerContract_Partner_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiskAnalysis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RiskScore = table.Column<double>(type: "float", nullable: false),
                    AnalysisDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskAnalysis_BusinessTopic_BusinessTopicId",
                        column: x => x.BusinessTopicId,
                        principalTable: "BusinessTopic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusinessContract",
                columns: new[] { "Id", "CreateDate", "Description", "EndDate", "Name", "StartDate", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("5928bf0e-f501-4095-9d54-570a2196d59f"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5490), "3. İş anlaşması", new DateTime(2024, 9, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5490), "İş Anlaşması 3", new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5490), null },
                    { new Guid("a0dbc67d-c032-46b1-b4e4-372f1af5280d"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5490), "1. İş anlaşması", new DateTime(2024, 7, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5480), "İş Anlaşması 1", new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5480), null },
                    { new Guid("b13a2a50-9a66-4a01-91ec-9246ff3970c1"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5490), "2. İş anlaşması", new DateTime(2024, 8, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5490), "İş Anlaşması 2", new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5490), null },
                    { new Guid("e6922d3a-b69b-43d0-90f4-ec34de7b268d"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5500), "4. İş anlaşması", new DateTime(2024, 7, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5500), "İş Anlaşması 4", new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(5500), null }
                });

            migrationBuilder.InsertData(
                table: "Partner",
                columns: new[] { "Id", "CreateDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("06500dc8-f77b-417d-bb5d-0d6ac7e3661a"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(6920), "İş Ortağı 2", null },
                    { new Guid("284e5ea4-32da-4643-84b9-b7a889f9fe78"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(6920), "İş Ortağı 3", null },
                    { new Guid("5b5aba2c-068c-4850-86ab-a4e2eca325ed"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(6910), "İş Ortağı 1", null },
                    { new Guid("83975a8c-637d-4cd8-b77e-1493f80a76cb"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(6920), "İş Ortağı 4", null }
                });

            migrationBuilder.InsertData(
                table: "BusinessTopic",
                columns: new[] { "Id", "BusinessContractId", "CreateDate", "Description", "PartnerId", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("3e00f72c-6b01-41dd-85de-0d7876e36dd4"), new Guid("5928bf0e-f501-4095-9d54-570a2196d59f"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(6400), "3. İş Konusu", new Guid("284e5ea4-32da-4643-84b9-b7a889f9fe78"), "İş Konusu 3", null },
                    { new Guid("56c98e67-275d-41fb-9662-cd557f3a4449"), new Guid("b13a2a50-9a66-4a01-91ec-9246ff3970c1"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(6400), "2. İş Konusu", new Guid("06500dc8-f77b-417d-bb5d-0d6ac7e3661a"), "İş Konusu 2", null },
                    { new Guid("73085f06-9b59-444c-bc73-559501584122"), new Guid("e6922d3a-b69b-43d0-90f4-ec34de7b268d"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(6400), "4. İş Konusu", new Guid("83975a8c-637d-4cd8-b77e-1493f80a76cb"), "İş Konusu 4", null },
                    { new Guid("c541a1cf-90d3-48d9-8fbc-93d42a984cff"), new Guid("a0dbc67d-c032-46b1-b4e4-372f1af5280d"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(6390), "1. İş Konusu", new Guid("5b5aba2c-068c-4850-86ab-a4e2eca325ed"), "İş Konusu 1", null }
                });

            migrationBuilder.InsertData(
                table: "PartnerContract",
                columns: new[] { "Id", "BusinessContractId", "CreateDate", "PartnerId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("25648d6a-643d-4877-87f6-daede8401870"), new Guid("e6922d3a-b69b-43d0-90f4-ec34de7b268d"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7280), new Guid("83975a8c-637d-4cd8-b77e-1493f80a76cb"), null },
                    { new Guid("488306db-7e95-4291-932b-e960f9217da1"), new Guid("b13a2a50-9a66-4a01-91ec-9246ff3970c1"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7270), new Guid("06500dc8-f77b-417d-bb5d-0d6ac7e3661a"), null },
                    { new Guid("5a7cf61b-176f-430f-8c6f-eaca016234af"), new Guid("5928bf0e-f501-4095-9d54-570a2196d59f"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7280), new Guid("284e5ea4-32da-4643-84b9-b7a889f9fe78"), null },
                    { new Guid("791f5e69-124d-4cf3-9027-ac5532c9c59a"), new Guid("a0dbc67d-c032-46b1-b4e4-372f1af5280d"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7270), new Guid("5b5aba2c-068c-4850-86ab-a4e2eca325ed"), null }
                });

            migrationBuilder.InsertData(
                table: "RiskAnalysis",
                columns: new[] { "Id", "AnalysisDate", "BusinessTopicId", "CreateDate", "RiskScore", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("85015a94-693b-4418-a164-ff437599fe9e"), new DateTime(2024, 6, 15, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7530), new Guid("c541a1cf-90d3-48d9-8fbc-93d42a984cff"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7530), 15.800000000000001, null },
                    { new Guid("9263e450-a593-4506-8e19-b6ac0df0f0c8"), new DateTime(2024, 6, 17, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7540), new Guid("73085f06-9b59-444c-bc73-559501584122"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7540), 53.399999999999999, null },
                    { new Guid("ba175a89-0e8b-481a-aeba-32d7599a4afe"), new DateTime(2024, 7, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7530), new Guid("56c98e67-275d-41fb-9662-cd557f3a4449"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7530), 30.100000000000001, null },
                    { new Guid("f4115479-0078-4f1d-8438-960315985f86"), new DateTime(2024, 6, 13, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7530), new Guid("3e00f72c-6b01-41dd-85de-0d7876e36dd4"), new DateTime(2024, 6, 10, 2, 3, 48, 679, DateTimeKind.Utc).AddTicks(7530), 75.0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTopic_BusinessContractId",
                table: "BusinessTopic",
                column: "BusinessContractId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessTopic_PartnerId",
                table: "BusinessTopic",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerContract_BusinessContractId",
                table: "PartnerContract",
                column: "BusinessContractId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerContract_PartnerId",
                table: "PartnerContract",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskAnalysis_BusinessTopicId",
                table: "RiskAnalysis",
                column: "BusinessTopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerContract");

            migrationBuilder.DropTable(
                name: "RiskAnalysis");

            migrationBuilder.DropTable(
                name: "BusinessTopic");

            migrationBuilder.DropTable(
                name: "BusinessContract");

            migrationBuilder.DropTable(
                name: "Partner");
        }
    }
}
