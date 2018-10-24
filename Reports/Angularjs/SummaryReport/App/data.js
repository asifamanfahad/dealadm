app.value('pageMethods', PageMethods);

app.factory('summary', function (pageMethods, $rootScope) {
    var result = [];
    pageMethods.GetSummary(function (data) {
        data.forEach(function (item) {
            result.push({
                couponId: item.couponId, couponQtn: item.couponQtn,
                dealId: item.dealId, dealTitle: item.dealTitle,
                podNumber: item.podNumber, orderFrom: item.orderFrom,
                courier: item.courier, companyName: item.companyName,
                crmConfirmationDate: item.crmConfirmationDate,
                folderName: item.folderName, comments: item.comments,
                couponPrice: item.couponPrice, commentedBy: item.commentedBy
            });
        });
        $rootScope.$apply();
    });
    return result;
})
