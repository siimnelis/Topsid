using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Topsid.Tests
{
    public class TopsCollectionTests
    {
        [Fact]
        public void KomplekteeribOigestiNaiteFailiTopsid()
        {
            var topsid = new List<Tops>
            {
                new Tops(1, 35, 15),
                new Tops(2, 29, 4),
                new Tops(3, 22, 11)
            };

            var topsidCollection = new TopsCollection(topsid);

            var komplektid = topsidCollection.Komplekteeri();

            Assert.Equal(1, komplektid[0].Topsid[0].Number);
            Assert.Equal(3, komplektid[0].Topsid[1].Number);
            Assert.Equal(2, komplektid[1].Topsid[0].Number);
        }

        [Fact]
        public void PanebTopsiTeiseTopsiSissePikali()
        {
            var topsid = new List<Tops>
            {
                new Tops(1, 40, 20),
                new Tops(2, 19, 39)
            };

            var topsidCollection = new TopsCollection(topsid);

            var komplektid = topsidCollection.Komplekteeri();

            Assert.Single(komplektid);

            Assert.Equal(1, komplektid[0].Topsid[0].Number);
            Assert.Equal(2, komplektid[0].Topsid[1].Number);

        }

        [Fact]
        public void SamaSuuredTopsidKomplekteeritakseEraldi()
        {
            var topsid = new List<Tops>
            {
                new Tops(1, 40, 20),
                new Tops(2, 40, 20)
            };

            var topsidCollection = new TopsCollection(topsid);

            var komplektid = topsidCollection.Komplekteeri();

            Assert.Equal(2, komplektid.Count);
        }
    }
}
