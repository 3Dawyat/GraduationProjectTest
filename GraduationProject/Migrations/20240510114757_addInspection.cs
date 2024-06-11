using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraduationProject.API.Migrations
{
    /// <inheritdoc />
    public partial class addInspection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Treatments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TreatmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inspections_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "Content", "Key", "Title" },
                values: new object[,]
                {
                    { 1, "There are several tomato varieties resistant to ToMV. Studies have found that tomatoes containing the Tm-22 gene could specifically resist to ToMV strains ToMV-0, ToMV-1 and ToMV-2. or ToMV is transmitted from plant to plant through vegetative propagation, grafting, and seeds. It is significantly important to ensure that any seeds planted are virus-free. This blocks ToMV from being spread to healthy plants through mechanical activities.", "Tomato___Tomato_mosaic_virus", "Tomato Mosaic Virus" },
                    { 2, "The products to use are chlorothalonil, copper oxychloride or mancozeb. Treatment should start when the first spots are seen and continue at 10-14-day intervals until 3-4 weeks before last harvest.", "Tomato___Target_Spot", "Target Spot" },
                    { 3, "For homeowners, copper products or copper plus mancozeb are registered and effective to control bacterial spot of tomato. For commercial growers, control of bacterial spot on greenhouse transplants by using streptomycin can prevent spread of the disease in the field.", "Tomato___Bacterial_spot", "Bacterial Spot" },
                    { 4, "Once infected with the virus, there are no treatments against the infection. Control the whitefly population to avoid the infection with the virus. Insecticides of the family of the pyrethroids used as soil drenches or spray during the seedling stage can reduce the population of whiteflies.", "Tomato___Tomato_Yellow_Leaf_Curl_Virus", "Tomato Yellow Leaf Curl Virus" },
                    { 5, "Strategies for managing late blight in tomato include planting resistant cultivars, eliminating volunteers (tomato plants that have re-seeded from the previous year's crop), spacing plants to increase airflow and reduce humidity, and applying preventive and effective fungicides to avoid infection.", "Tomato___Late_blight", "Late Blight" },
                    { 6, "Remove and destroy all affected plant parts. For plants growing under cover, increase ventilation and, if possible, the space between plants. Try to avoid wetting the leaves when watering plants, especially when watering in the evening. Copper-based fungicides can be used to control diseases on tomatoes.", "Tomato___Leaf_Mold", "Leaf Mold" },
                    { 7, "Fungicides, crop rotation, and removal of infected plant material are key management practices and Give your tools a quick scrub to remove soil, then dip or spray them with a mild bleach solution.", "Tomato___Early_blight", "Early Blight" },
                    { 8, "Miticides, predatory mites, and maintaining plant vigor help control spider mite infestations.", "Tomato___Spider_mites Two-spotted_spider_mite", "Two-Spotted Spider Mites" },
                    { 9, "Remove diseased leaves, improve air circulation around the plants, mulch around the base of the plants, do not use overhead watering, control weeds, use crop rotation, and use fungicidal sprays.", "Tomato___Septoria_leaf_spot", "Septoria Leaf Spot" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_TreatmentId",
                table: "Inspections",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_UserId",
                table: "Inspections",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Treatments");
        }
    }
}
