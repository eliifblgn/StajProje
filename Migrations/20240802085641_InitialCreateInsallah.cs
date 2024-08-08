 using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecKaliteDb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateInsallah : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BedenNumara",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beden = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedenNumara", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Birim",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KkdGrubu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KkdGrubuAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KkdGrubu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonelBirim",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelBirim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unvan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnvanAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unvan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KkdNiteligi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KkdNiteligiAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KkdGrubuId = table.Column<long>(type: "bigint", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KkdNiteligi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KkdNiteligi_KkdGrubu_KkdGrubuId",
                        column: x => x.KkdGrubuId,
                        principalTable: "KkdGrubu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SicilNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelBirimId = table.Column<long>(type: "bigint", nullable: false),
                    UnvanId = table.Column<long>(type: "bigint", nullable: false),
                    KkdEnvanterTakipId = table.Column<long>(type: "bigint", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personel_PersonelBirim_PersonelBirimId",
                        column: x => x.PersonelBirimId,
                        principalTable: "PersonelBirim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personel_Unvan_UnvanId",
                        column: x => x.UnvanId,
                        principalTable: "Unvan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Iade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<long>(type: "bigint", nullable: false),
                    IadeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnvanterDurumu = table.Column<int>(type: "int", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Iade_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KkdEnvanterTakip",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<long>(type: "bigint", nullable: false),
                    BedenNumaraId = table.Column<long>(type: "bigint", nullable: false),
                    KkdNiteligiId = table.Column<long>(type: "bigint", nullable: true),
                    KkdGrubuId = table.Column<long>(type: "bigint", nullable: false),
                    BirimId = table.Column<long>(type: "bigint", nullable: false),
                    TeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false),
                    OlusturanId = table.Column<long>(type: "bigint", nullable: true),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DegistirenId = table.Column<long>(type: "bigint", nullable: true),
                    DegistirmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KkdEnvanterTakip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KkdEnvanterTakip_BedenNumara_BedenNumaraId",
                        column: x => x.BedenNumaraId,
                        principalTable: "BedenNumara",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KkdEnvanterTakip_Birim_BirimId",
                        column: x => x.BirimId,
                        principalTable: "Birim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KkdEnvanterTakip_KkdGrubu_KkdGrubuId",
                        column: x => x.KkdGrubuId,
                        principalTable: "KkdGrubu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KkdEnvanterTakip_KkdNiteligi_KkdNiteligiId",
                        column: x => x.KkdNiteligiId,
                        principalTable: "KkdNiteligi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KkdEnvanterTakip_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teslimat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<long>(type: "bigint", nullable: false),
                    TeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnvanterDurumu = table.Column<int>(type: "int", nullable: false),
                    Silindi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teslimat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teslimat_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Iade_PersonelId",
                table: "Iade",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_KkdEnvanterTakip_BedenNumaraId",
                table: "KkdEnvanterTakip",
                column: "BedenNumaraId");

            migrationBuilder.CreateIndex(
                name: "IX_KkdEnvanterTakip_BirimId",
                table: "KkdEnvanterTakip",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_KkdEnvanterTakip_KkdGrubuId",
                table: "KkdEnvanterTakip",
                column: "KkdGrubuId");

            migrationBuilder.CreateIndex(
                name: "IX_KkdEnvanterTakip_KkdNiteligiId",
                table: "KkdEnvanterTakip",
                column: "KkdNiteligiId");

            migrationBuilder.CreateIndex(
                name: "IX_KkdEnvanterTakip_PersonelId",
                table: "KkdEnvanterTakip",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_KkdNiteligi_KkdGrubuId",
                table: "KkdNiteligi",
                column: "KkdGrubuId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_PersonelBirimId",
                table: "Personel",
                column: "PersonelBirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_UnvanId",
                table: "Personel",
                column: "UnvanId");

            migrationBuilder.CreateIndex(
                name: "IX_Teslimat_PersonelId",
                table: "Teslimat",
                column: "PersonelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Iade");

            migrationBuilder.DropTable(
                name: "KkdEnvanterTakip");

            migrationBuilder.DropTable(
                name: "Teslimat");

            migrationBuilder.DropTable(
                name: "BedenNumara");

            migrationBuilder.DropTable(
                name: "Birim");

            migrationBuilder.DropTable(
                name: "KkdNiteligi");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "KkdGrubu");

            migrationBuilder.DropTable(
                name: "PersonelBirim");

            migrationBuilder.DropTable(
                name: "Unvan");
        }
    }
}
