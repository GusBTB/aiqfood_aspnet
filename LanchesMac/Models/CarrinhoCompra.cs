using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models {
    public class CarrinhoCompra {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context) {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services) {
            //define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context) {
                CarrinhoCompraId = carrinhoId
            };

        }

        public void AdicionarAoCarrinho(Lanche lanche) {
            //ver se o produto (CarrinhoCompraItem) ja existe no carrinho
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                    s => s.Lanche.LancheId == lanche.LancheId &&
                    s.CarrinhoCompraId == CarrinhoCompraId
                );
            if (carrinhoCompraItem == null) {
                //criando um item com o id desse carrinho de compra, com o lanche que foi passado e quantidade 1
                var carrCompraItem = new CarrinhoCompraItem {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrCompraItem);
            } else {
                //quantidade++
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Lanche lanche) {
            //achar o produto
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                    s => s.Lanche.LancheId == lanche.LancheId &&
                    s.CarrinhoCompraId == CarrinhoCompraId
                );
            var quantidadeLocal = 0;
            if (carrinhoCompraItem != null) {
                if (carrinhoCompraItem.Quantidade < 1) {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                } else {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens() {
            return CarrinhoCompraItens ??=
                _context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Include(s => s.Lanche)
                .ToList();
        }

        public void LimparCarrinho() {
            var carrinhoItens = _context.CarrinhoCompraItens.Where(carr => carr.CarrinhoCompraId == CarrinhoCompraId);
            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal() {
            var total = _context.CarrinhoCompraItens.Where(carr => carr.CarrinhoCompraId == CarrinhoCompraId).Select(carr => carr.Lanche.Preco * carr.Quantidade).Sum();
            return total;
        }

    }
}
