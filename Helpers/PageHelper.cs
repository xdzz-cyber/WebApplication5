using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.Helpers
{
    public static class PageHelper
    {
        public static IEnumerable<double> optimizedPageNumbers(double PageNumber, double PagesCount)
        {

            List<double> optimizedPaginationPages = new List<double>();
            if (PagesCount <= 5)
            {
                for (double i = 1; i <= PagesCount; i++)
                {
                    optimizedPaginationPages.Add(i);
                }
            }
            else
            {
                double midPoint = PageNumber < 3 ? 3 : PageNumber > PagesCount - 2 ? PagesCount - 2 : PageNumber;

                for (double i = midPoint - 1; i <= midPoint + 1; i++)
                {
                    optimizedPaginationPages.Add(i);
                }

                if (optimizedPaginationPages[0] != 1)
                {
                    optimizedPaginationPages.Insert(0, 1);

                    if (optimizedPaginationPages[1] - optimizedPaginationPages[0] > 1)
                    {
                        optimizedPaginationPages.Insert(1, -1);
                    }
                }

                if (optimizedPaginationPages[optimizedPaginationPages.Count - 1] != PagesCount)
                {
                    optimizedPaginationPages.Insert(optimizedPaginationPages.Count, PagesCount);
                    if (optimizedPaginationPages[optimizedPaginationPages.Count - 1] - optimizedPaginationPages[optimizedPaginationPages.Count - 2] > 1)
                    {
                        optimizedPaginationPages.Insert(optimizedPaginationPages.Count - 1, -1);
                    }
                }
            }



            return optimizedPaginationPages;
        }
    }
}
