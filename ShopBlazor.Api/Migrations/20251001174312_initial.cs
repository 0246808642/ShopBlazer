using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopBlazor.Api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IconCSS = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameUser = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CartId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCarts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CartId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1L, "1" },
                    { 2L, "2" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IconCSS", "Name" },
                values: new object[,]
                {
                    { 1L, "fas fa-spa", "Beleza" },
                    { 2L, "fas fa-couch", "Moveis" },
                    { 3L, "fas fa-headphones", "Eletronicos" },
                    { 4L, "fas fa-shoe-prints", "Calcados" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CartId", "NameUser" },
                values: new object[,]
                {
                    { 1L, null, "Caique" },
                    { 2L, null, "Isabela" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1L, 1L, "Um kit fornecido pela Natura, contendo produtos para cuidados com a pele", "/Imagens/Beleza/Beleza1.png", "Glossier - Beleza Kit", 100m, 100 },
                    { 2L, 1L, "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele", "/Imagens/Beleza/Beleza2.png", "Curology - Kit para Pele", 50m, 45 },
                    { 3L, 1L, "Um kit fornecido pela Glossier, contendo produtos para cuidados com a pele", "/Imagens/Beleza/Beleza3.png", "Óleo de Coco Orgânico", 20m, 30 },
                    { 4L, 1L, "Um kit fornecido pela Curology, contendo produtos para cuidados com a pele", "/Imagens/Beleza/Beleza4.png", "Schwarzkopf - Kit de cuidados com a pele e cabelo", 50m, 60 },
                    { 5L, 1L, "Kit de cuidados com a pele, contendo produtos para cuidados com a pele e cabelos", "/Imagens/Beleza/Beleza5.png", "Kit de cuidados com a pele", 30m, 85 },
                    { 6L, 3L, "Air Pods - fones de ouvido sem fio intra-auriculares", "/Imagens/Eletronicos/eletronico1.png", "Fones de ouvidos", 100m, 120 },
                    { 7L, 3L, "Fones de ouvido dourados na orelha - esses fones de ouvido não são sem fio", "/Imagens/Eletronicos/eletronico2.png", "Fones de ouvido dourados", 40m, 200 },
                    { 8L, 3L, "Fones de ouvido pretos na orelha - esses fones de ouvido não são sem fio", "/Imagens/Eletronicos/eletronico3.png", "Fones de ouvido pretos", 40m, 300 },
                    { 9L, 3L, "Câmera Digital Sennheiser - Câmera digital de alta qualidade fornecida pela Sennheiser - inclui tripé", "/Imagens/Eletronicos/eletronico4.png", "Câmera digital Sennheiser com tripé", 600m, 20 },
                    { 10L, 3L, "Canon Digital Camera - Câmera digital de alta qualidade fornecida pela Canon", "/Imagens/Eletronicos/eletronico5.png", "Câmera Digital Canon", 500m, 15 },
                    { 11L, 3L, "Gameboy - Fornecido por Nintendo", "/Imagens/Eletronicos/tecnologia6.png", "Nintendo Gameboy", 100m, 60 },
                    { 12L, 2L, "Cadeira de escritório em couro preto muito confortável", "/Imagens/Moveis/moveis1.png", "Cadeira de escritório de couro preto", 50m, 212 },
                    { 13L, 2L, "Cadeira de escritório em couro rosa muito confortável", "/Imagens/Moveis/moveis2.png", "Cadeira de escritório de couro rosa", 50m, 112 },
                    { 14L, 2L, "Poltrona muito confortável", "/Imagens/Moveis/moveis3.png", "Espreguiçadeira", 70m, 90 },
                    { 15L, 2L, "Poltrona prateada muito confortável", "/Imagens/Moveis/moveis4.png", "Silver Lounge Chair", 120m, 95 },
                    { 16L, 2L, "Abajur de mesa de porcelana branco e azul", "/Imagens/Moveis/moveis6.png", "Luminária de mesa de porcelana", 15m, 100 },
                    { 17L, 2L, "Abajur de mesa de escritório", "/Imagens/Moveis/moveis7.png", "Office Table Lamp", 20m, 73 },
                    { 18L, 4L, "Tênis Puma confortáveis na maioria dos tamanhos", "/Imagens/Calcados/calcado1.png", "Tênis Puma", 100m, 50 },
                    { 19L, 4L, "Tênis coloridos - disponíveis na maioria dos tamanhos", "/Imagens/Calcados/calcado2.png", "Tênis Colodiros", 150m, 60 },
                    { 20L, 4L, "Tênis Nike azul - disponível na maioria dos tamanhos", "/Imagens/Calcados/calcado3.png", "Tênis Nike Azul", 200m, 70 },
                    { 21L, 4L, "Treinadores Hummel coloridos - disponíveis na maioria dos tamanhos", "/Imagens/Calcados/calcado4.png", "Tênis Hummel Coloridos", 120m, 120 },
                    { 22L, 4L, "Tênis Nike vermelho - disponível na maioria dos tamanhos", "/Imagens/Calcados/calcado5.png", "Tênis Nike Vermelho", 200m, 100 },
                    { 23L, 4L, "Sandálias Birkenstock - disponíveis na maioria dos tamanhos", "/Imagens/Calcados/calcado6.png", "Sandálidas Birkenstock", 50m, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarts_CartId",
                table: "ItemCarts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarts_ProductId",
                table: "ItemCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CartId",
                table: "Users",
                column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCarts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
