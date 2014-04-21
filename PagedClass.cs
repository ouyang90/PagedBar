using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public class PagedClass
    {
        // .paged a  
        //{  
        //    padding: 2px 4px;  
        //    margin-right: 4px;  
        //    border: 1px solid #ccc;  
        //    text-decoration: none;  
        //}  
        //.paged .current  
        //{  
        //    padding: 2px 4px;  
        //    margin-right: 4px;  
        //    font-weight: bold;  
        //} 
        //$(".paged a").mouseover(function () {
        //    $(this).css('backgroundColor', '#9CAAC1');
        //}).mouseout(function () {
        //    $(this).css('backgroundColor', '');
        //});
        /// <summary>  
        /// 分页代码  
        /// </summary>  
        /// <param name="totalPageCount">总页数</param>  
        /// <param name="pageSize">每一页的大小</param>  
        /// <param name="currentPage">当前页码</param>  
        /// <returns>分页的html</returns>  
        public static string Paging(int totalPageCount, int pageSize, int currentPage, string page)
        {
            string pageUrl = "";
            int step = 2;

            int leftNum;
            int rightNum;

            pageUrl += "<div class='paged'>";
            //是否显示上一页  
            if (currentPage > 1)
            {
                pageUrl += "<a href='" + page + "?page=" + (currentPage - 1) + "'>上一页</a>";
            }


            //此时应该这样显示页码 上一页 1 ...  5 6 7 8 9 ... 100 下一页  
            //即当前浏览的页数在中间几页  
            if ((currentPage - step) > 2 && (totalPageCount > step * 2 + 2))
            {


                pageUrl += "<a href='" + page + "?page=1'>1</a>";


                //标识变量，标识当前页是否是倒数几页，该变量在下面会用到  
                bool isLastFiewPages = false;


                //判断是否是倒数后几页  
                if (currentPage + (step * 2 + 1 + 1) > totalPageCount)
                {
                    leftNum = totalPageCount - (step * 2 + 1);
                    rightNum = totalPageCount;
                    isLastFiewPages = true;
                }
                else
                {
                    leftNum = currentPage - step;
                    rightNum = currentPage + step;
                }


                if (leftNum - 1 > 1)
                {
                    pageUrl += "<span>...</span>";
                }


                //拼装分页代码  
                for (int i = leftNum; i <= rightNum; i++)
                {
                    if (i == currentPage)
                    {
                        pageUrl = pageUrl + "<span class='current'>" + i + "</span>";
                    }
                    else
                    {
                        pageUrl = pageUrl + "<a href='" + page + "?page=" + i + "'>" + i + "</a>";
                    }
                }
                if (!isLastFiewPages)
                {
                    pageUrl += "<span>...</span><a href='" + page + "?page=" + totalPageCount + "'>" + totalPageCount + "</a>";
                }


            }
            //此时应该这样显示页码 上一页 1 2 3 4 5 6 ... 100 下一页或者  
            //当总页数小于或等于(2 * step + 1 + 1)的时候应该这样显示 上一页 1 2 3 4 5 下一页  
            else
            {
                if (currentPage <= 0)
                {
                    currentPage = 1;
                }


                leftNum = 1;
                //rightNum总页数和step * 2 + 1 + 1中较小的那个，  
                rightNum = totalPageCount < (step * 2 + 1 + 1) ? totalPageCount : (step * 2 + 2);


                for (int i = leftNum; i <= rightNum; i++)
                {
                    if (i == currentPage)
                    {
                        pageUrl += "<span class='current'>" + currentPage + "</span>";
                    }
                    else
                    {
                        pageUrl += "<a href='" + page + "?page=" + i + "'>" + i + "</a>";
                    }
                }


                //如果总条数大于前几页连续显示的条数需要这样显示 上一页 1 2 3 4 5 6 ... 100 下一页  
                if (totalPageCount > (step * 2 + 2))
                {
                    if (totalPageCount - 1 > rightNum)
                    {
                        pageUrl += "<span>...</span>";
                    }
                    pageUrl += "<a href='" + page + "?page=" + totalPageCount + "'>" + totalPageCount + "</a>";
                }
            }

            if (currentPage < totalPageCount)
            {
                pageUrl += "<a href='" + page + "?page=" + (currentPage + 1) + "'>下一页</a>";
            }
            pageUrl += "</div>";
            return pageUrl;
        }

    }
}