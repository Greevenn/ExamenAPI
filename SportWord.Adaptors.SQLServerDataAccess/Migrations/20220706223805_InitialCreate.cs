using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportWord.Adaptors.SQLServerDataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    carrito_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.carrito_id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    categoria_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.categoria_id);
                });

            migrationBuilder.CreateTable(
                name: "Promocion",
                columns: table => new
                {
                    promocion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    producto_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocion", x => x.promocion_id);
                });

            migrationBuilder.CreateTable(
                name: "Tiendas",
                columns: table => new
                {
                    tienda_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiendas", x => x.tienda_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuario_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.usuario_id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<double>(type: "float", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    promocion_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.producto_id);
                    table.ForeignKey(
                        name: "FK_Productos_Promocion_promocion_id",
                        column: x => x.promocion_id,
                        principalTable: "Promocion",
                        principalColumn: "promocion_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuario_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    Fecha_compra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usersusuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.compra_id);
                    table.ForeignKey(
                        name: "FK_Compra_User_Usersusuario_id",
                        column: x => x.Usersusuario_id,
                        principalTable: "User",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Tienda",
                columns: table => new
                {
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tienda_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Userusuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Tienda", x => new { x.usuario_id, x.tienda_id });
                    table.ForeignKey(
                        name: "FK_User_Tienda_Tiendas_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Tiendas",
                        principalColumn: "tienda_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Tienda_User_Userusuario_id",
                        column: x => x.Userusuario_id,
                        principalTable: "User",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carrito_Productos",
                columns: table => new
                {
                    carrito_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito_Productos", x => new { x.producto_id, x.carrito_id });
                    table.ForeignKey(
                        name: "FK_Carrito_Productos_Carrito_producto_id",
                        column: x => x.producto_id,
                        principalTable: "Carrito",
                        principalColumn: "carrito_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrito_Productos_Productos_carrito_id",
                        column: x => x.carrito_id,
                        principalTable: "Productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos_Categorias",
                columns: table => new
                {
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoria_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos_Categorias", x => new { x.producto_id, x.categoria_id });
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_Categorias_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "Categorias",
                        principalColumn: "categoria_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_Productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "Productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Producto",
                columns: table => new
                {
                    usuario_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Producto", x => new { x.usuario_id, x.producto_id });
                    table.ForeignKey(
                        name: "FK_User_Producto_Productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "Productos",
                        principalColumn: "producto_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Producto_User_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "User",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_Productos_carrito_id",
                table: "Carrito_Productos",
                column: "carrito_id");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Usersusuario_id",
                table: "Compra",
                column: "Usersusuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_promocion_id",
                table: "Productos",
                column: "promocion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Categorias_categoria_id",
                table: "Productos_Categorias",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Producto_producto_id",
                table: "User_Producto",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Tienda_Userusuario_id",
                table: "User_Tienda",
                column: "Userusuario_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito_Productos");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Productos_Categorias");

            migrationBuilder.DropTable(
                name: "User_Producto");

            migrationBuilder.DropTable(
                name: "User_Tienda");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Tiendas");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Promocion");
        }
    }
}
