using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REMIwebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id_categoria = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    nombreCat = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__4A033A93BC4D705C", x => x.Id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    correo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cliente__FCE039921AECE439", x => x.Id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "metodo_de_pago",
                columns: table => new
                {
                    Id_metodo = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Desc_metodo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__metodo_d__AB62E2F2894D648B", x => x.Id_metodo);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    Id_Proveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreProveedor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    direccionProveedor = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    telefonoProveedor = table.Column<int>(type: "int", nullable: true),
                    correoProveedor = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__proveedo__477B858ED1A07C53", x => x.Id_Proveedor);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id_Rol = table.Column<int>(type: "int", nullable: false),
                    Desc_rol = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__roles__55932E861BDE0F82", x => x.Id_Rol);
                });

            migrationBuilder.CreateTable(
                name: "tipo_documento",
                columns: table => new
                {
                    Id_tdoc = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Desc_tdoc = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Estado = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tipo_doc__717EF98083B9F9C0", x => x.Id_tdoc);
                });

            migrationBuilder.CreateTable(
                name: "subcategorias",
                columns: table => new
                {
                    Id_subcategoria = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    nombreSub = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Categoria = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__subcateg__5C3FC4A02D40F64A", x => x.Id_subcategoria);
                    table.ForeignKey(
                        name: "FK__subcatego__Categ__45F365D3",
                        column: x => x.Categoria,
                        principalTable: "categorias",
                        principalColumn: "Id_categoria");
                });

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id_Persona = table.Column<int>(type: "int", nullable: false),
                    primerNombre = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    segundoNombre = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    primerApellido = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    segundoApellido = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Correo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    TelefonoCel = table.Column<long>(type: "bigint", nullable: true),
                    Contrasena = table.Column<byte[]>(type: "varbinary(130)", maxLength: 130, nullable: true),
                    tipoDoc = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__persona__C95634AFE6B01855", x => x.Id_Persona);
                    table.ForeignKey(
                        name: "FK__persona__tipoDoc__3B75D760",
                        column: x => x.tipoDoc,
                        principalTable: "tipo_documento",
                        principalColumn: "Id_tdoc");
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    cod_Producto = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Referencia = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    marcaProducto = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    precioDocena = table.Column<double>(type: "float", nullable: true),
                    Subcategoria = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Proveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__producto__C6B2843F231FCCB1", x => x.cod_Producto);
                    table.ForeignKey(
                        name: "FK__productos__Prove__49C3F6B7",
                        column: x => x.Proveedor,
                        principalTable: "proveedores",
                        principalColumn: "Id_Proveedor");
                    table.ForeignKey(
                        name: "FK__productos__Subca__48CFD27E",
                        column: x => x.Subcategoria,
                        principalTable: "subcategorias",
                        principalColumn: "Id_subcategoria");
                });

            migrationBuilder.CreateTable(
                name: "persona_has_roles",
                columns: table => new
                {
                    persona_Id_Persona = table.Column<int>(type: "int", nullable: false),
                    roles_Id_Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__persona___44FBF1518E916752", x => new { x.persona_Id_Persona, x.roles_Id_Rol });
                    table.ForeignKey(
                        name: "FK__persona_h__perso__3E52440B",
                        column: x => x.persona_Id_Persona,
                        principalTable: "persona",
                        principalColumn: "Id_Persona");
                    table.ForeignKey(
                        name: "FK__persona_h__roles__3F466844",
                        column: x => x.roles_Id_Rol,
                        principalTable: "roles",
                        principalColumn: "Id_Rol");
                });

            migrationBuilder.CreateTable(
                name: "recibo_pago",
                columns: table => new
                {
                    Id_recibo = table.Column<int>(type: "int", nullable: false),
                    nombreNegocio = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    Persona = table.Column<int>(type: "int", nullable: false),
                    Id_cliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__recibo_p__64A18CFCAA026CAC", x => x.Id_recibo);
                    table.ForeignKey(
                        name: "FK__recibo_pa__Id_cl__5535A963",
                        column: x => x.Id_cliente,
                        principalTable: "cliente",
                        principalColumn: "Id_cliente");
                    table.ForeignKey(
                        name: "FK__recibo_pa__Perso__5441852A",
                        column: x => x.Persona,
                        principalTable: "persona",
                        principalColumn: "Id_Persona");
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    Id_stock = table.Column<int>(type: "int", nullable: false),
                    stockMax = table.Column<int>(type: "int", nullable: true),
                    stockMin = table.Column<int>(type: "int", nullable: true),
                    cantidadActual = table.Column<int>(type: "int", nullable: true),
                    estadoProducto = table.Column<byte>(type: "tinyint", nullable: true),
                    productoStock = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__stock__89C929197FF27049", x => x.Id_stock);
                    table.ForeignKey(
                        name: "FK__stock__productoS__4CA06362",
                        column: x => x.productoStock,
                        principalTable: "productos",
                        principalColumn: "cod_Producto");
                });

            migrationBuilder.CreateTable(
                name: "recibo_pago_has_metodo",
                columns: table => new
                {
                    recibo_pago_Id_recibo = table.Column<int>(type: "int", nullable: false),
                    recibo_pago_Persona = table.Column<int>(type: "int", nullable: false),
                    metodo_de_pago_Id_metodo = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__recibo_p__10972F1BA096082F", x => new { x.recibo_pago_Id_recibo, x.recibo_pago_Persona, x.metodo_de_pago_Id_metodo });
                    table.ForeignKey(
                        name: "FK__recibo_pa__metod__5FB337D6",
                        column: x => x.metodo_de_pago_Id_metodo,
                        principalTable: "metodo_de_pago",
                        principalColumn: "Id_metodo");
                    table.ForeignKey(
                        name: "FK__recibo_pa__recib__5DCAEF64",
                        column: x => x.recibo_pago_Id_recibo,
                        principalTable: "recibo_pago",
                        principalColumn: "Id_recibo");
                    table.ForeignKey(
                        name: "FK__recibo_pa__recib__5EBF139D",
                        column: x => x.recibo_pago_Persona,
                        principalTable: "persona",
                        principalColumn: "Id_Persona");
                });

            migrationBuilder.CreateTable(
                name: "recibo_productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    valorUnitario = table.Column<double>(type: "float", nullable: true),
                    Subtotal = table.Column<double>(type: "float", nullable: true),
                    reciboPago = table.Column<int>(type: "int", nullable: false),
                    Producto = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__recibo_p__3214EC071095D27E", x => x.Id);
                    table.ForeignKey(
                        name: "FK__recibo_pr__Produ__59063A47",
                        column: x => x.Producto,
                        principalTable: "productos",
                        principalColumn: "cod_Producto");
                    table.ForeignKey(
                        name: "FK__recibo_pr__recib__5812160E",
                        column: x => x.reciboPago,
                        principalTable: "recibo_pago",
                        principalColumn: "Id_recibo");
                });

            migrationBuilder.CreateTable(
                name: "movimientos_stock",
                columns: table => new
                {
                    Id_movimiento = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    Observaciones = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__movimien__7B67F72A8EA7C94E", x => x.Id_movimiento);
                    table.ForeignKey(
                        name: "FK__movimient__Stock__4F7CD00D",
                        column: x => x.Stock,
                        principalTable: "stock",
                        principalColumn: "Id_stock");
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimientos_stock_Stock",
                table: "movimientos_stock",
                column: "Stock");

            migrationBuilder.CreateIndex(
                name: "IX_persona_tipoDoc",
                table: "persona",
                column: "tipoDoc");

            migrationBuilder.CreateIndex(
                name: "IX_persona_has_roles_roles_Id_Rol",
                table: "persona_has_roles",
                column: "roles_Id_Rol");

            migrationBuilder.CreateIndex(
                name: "IX_productos_Proveedor",
                table: "productos",
                column: "Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_productos_Subcategoria",
                table: "productos",
                column: "Subcategoria");

            migrationBuilder.CreateIndex(
                name: "IX_recibo_pago_Id_cliente",
                table: "recibo_pago",
                column: "Id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_recibo_pago_Persona",
                table: "recibo_pago",
                column: "Persona");

            migrationBuilder.CreateIndex(
                name: "IX_recibo_pago_has_metodo_metodo_de_pago_Id_metodo",
                table: "recibo_pago_has_metodo",
                column: "metodo_de_pago_Id_metodo");

            migrationBuilder.CreateIndex(
                name: "IX_recibo_pago_has_metodo_recibo_pago_Persona",
                table: "recibo_pago_has_metodo",
                column: "recibo_pago_Persona");

            migrationBuilder.CreateIndex(
                name: "IX_recibo_productos_Producto",
                table: "recibo_productos",
                column: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_recibo_productos_reciboPago",
                table: "recibo_productos",
                column: "reciboPago");

            migrationBuilder.CreateIndex(
                name: "IX_stock_productoStock",
                table: "stock",
                column: "productoStock");

            migrationBuilder.CreateIndex(
                name: "IX_subcategorias_Categoria",
                table: "subcategorias",
                column: "Categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimientos_stock");

            migrationBuilder.DropTable(
                name: "persona_has_roles");

            migrationBuilder.DropTable(
                name: "recibo_pago_has_metodo");

            migrationBuilder.DropTable(
                name: "recibo_productos");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "metodo_de_pago");

            migrationBuilder.DropTable(
                name: "recibo_pago");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "subcategorias");

            migrationBuilder.DropTable(
                name: "tipo_documento");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
