function createPagedBarHtml(totalPageCount, currentPage) {
    if (totalPageCount == 0) {
        return "";
    }
    //分页的html代码
    var pagedHtml = "";

    var step = 2;

    var leftNum;
    var rightNum;

    pagedHtml += "<div class='paged' id='pageBar'>";

    if (currentPage != 1) {
        //显示首页
        pagedHtml += "<a href='javascript:void(0);' onclick='" + getClick(1) + "' class='firstpage' >首页</a>";
    }

    //是否显示上一页  
    if (currentPage > 1) {
        pagedHtml += "<a href='javascript:void(0);' onclick='" + getClick(currentPage - 1) + "'>上页</a>";
    }

    //此时应该这样显示页码 上一页 1 ...  5 6 7 8 9 ... 100 下一页  
    //即当前浏览的页数在中间几页  
    if ((currentPage - step) > 2 && (totalPageCount > step * 2 + 2)) {
        pagedHtml += "<a href='javascript:void(0);' onclick='" + getClick(1) + "'>1</a>";

        //标识变量，标识当前页是否是倒数几页，该变量在下面会用到  
        var isLastFiewPages = false;

        //判断是否是倒数后几页  
        if (currentPage + (step * 2 + 1 + 1) > totalPageCount) {
            leftNum = totalPageCount - (step * 2 + 1);
            rightNum = totalPageCount;
            isLastFiewPages = true;
        }
        else {
            leftNum = currentPage - step;
            rightNum = currentPage + step;
        }


        if (leftNum - 1 > 1) {
            pagedHtml += "<span>...</span>";
        }

        //拼装分页代码  
        for (var i = leftNum; i <= rightNum; i++) {
            if (i == currentPage) {
                pagedHtml = pagedHtml + "<span class='current'>" + i + "</span>";
            }
            else {
                pagedHtml = pagedHtml + "<a href='javascript:void(0);' onclick='" + getClick(i) + "'>" + i + "</a>";
            }
        }
        if (!isLastFiewPages) {
            pagedHtml += "<span>...</span><a href='javascript:void(0);' onclick='" + getClick(totalPageCount) + "'>" + totalPageCount + "</a>";
        }
    }
    //此时应该这样显示页码 上一页 1 2 3 4 5 6 ... 100 下一页或者  
    //当总页数小于或等于(2 * step + 1 + 1)的时候应该这样显示 上一页 1 2 3 4 5 下一页  
    else {
        if (currentPage <= 0) {
            currentPage = 1;
        }

        leftNum = 1;
        //rightNum总页数和step * 2 + 1 + 1中较小的那个，  
        rightNum = totalPageCount < (step * 2 + 1 + 1) ? totalPageCount : (step * 2 + 2);


        for (var i = leftNum; i <= rightNum; i++) {
            if (i == currentPage) {
                pagedHtml += "<span class='current'>" + currentPage + "</span>";
            }
            else {
                pagedHtml += "<a href='javascript:void(0);' onclick='" + getClick(i) + "'>" + i + "</a>";
            }
        }

        //如果总条数大于前几页连续显示的条数需要这样显示 上一页 1 2 3 4 5 6 ... 100 下页  
        if (totalPageCount > (step * 2 + 2)) {
            if (totalPageCount - 1 > rightNum) {
                pagedHtml += "<span>...</span>";
            }
            pagedHtml += "<a href='javascript:void(0);' onclick='" + getClick(totalPageCount) + "'>" + totalPageCount + "</a>";
        }
    }

    if (currentPage < totalPageCount) {
        pagedHtml += "<a href='javascript:void(0);' onclick='" + getClick(currentPage + 1) + "'>下页</a>";
    }

    if (currentPage != totalPageCount) {
        //显示尾页
        pagedHtml += "<a href='javascript:void(0);' onclick='" + getClick(totalPageCount) + "' class='lastpage'>末页</a>";
    }

    pagedHtml += "</div>";

    return pagedHtml;
}