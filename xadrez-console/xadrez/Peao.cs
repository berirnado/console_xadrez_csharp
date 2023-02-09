
using xadrez_console.tabuleiro;

namespace xadrez
{
    internal class Peao : Peca
    {
        private PartidaXadrez partida;
        public bool realizouEnPassant { get; private set; }
        public Peao(Tabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
            realizouEnPassant = false;
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

            }
            // #jogadaespecial en passant
            if (posicao.linha == 3)
            {
                Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && partida.tab.peca(esquerda) == partida.vulneravelEnPassant)
                {
                    mat[esquerda.linha - 1, esquerda.coluna] = true;
                    this.realizouEnPassant = true;
                }
                if (tab.posicaoValida(direita) && existeInimigo(direita) && partida.tab.peca(direita) == partida.vulneravelEnPassant)
                {
                    mat[direita.linha - 1, direita.coluna] = true;
                    this.realizouEnPassant = true;
                }
            }

            if (posicao.linha == 3)
            {
                Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && partida.tab.peca(esquerda) == partida.vulneravelEnPassant)
                {
                    mat[esquerda.linha - 1, esquerda.coluna] = true;
                    realizouEnPassant = true;
                }
                if (tab.posicaoValida(direita) && existeInimigo(direita) && partida.tab.peca(direita) == partida.vulneravelEnPassant)
                {
                    mat[direita.linha - 1, direita.coluna] = true;
                    realizouEnPassant = true;
                }
            }

            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
