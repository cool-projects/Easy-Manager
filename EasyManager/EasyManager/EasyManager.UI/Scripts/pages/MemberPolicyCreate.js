
    $(document).ready(function () {
        LoadPoliciesList();
    })

var cost = +0;
var fees = +0;
function GenerateMonthlyFee() {
    fees = $("#adminFee").val();
    //var benefitsCost = $("#lblMonthlyFee").text();
    $("#lblAdminFee").text(fees);
    $("#lblMonthlyFee").text(+fees + +cost);
}
function btnAddBenefitsClick() {
    var benfee = +0;
    $("#lblBenefits").empty();
    $("#lblBenefitId").empty();
    var i = 0;
    $('input[name="benefits"]:checked').each(function () {
        if (i == 0) {
            $("#lblBenefits").append(this.value);
        }
        else {
            $("#lblBenefits").append(", " + this.value);
        }
        i++;
        $("#lblBenefitId").append(this.id + ", ");
        benfee += +(this.alt);
    });
    cost = benfee;
    $("#lblMonthlyFee").empty();
    $("#lblMonthlyFee").text(+benfee + +fees);

    //un-check boxes
    $('input[name="benefits"]:checked').each(function () {
        $('input[name="benefits"]').prop('checked', false);
    });
}

function LoadPoliciesList() {
    $.ajax({
        cache: false,
        type: "GET",
        url: '@Url.Action("GetPolicies", "MemberPolicy")',
        success: function (data) {
            var $placeholder = $("#dvPoliciesList");
            $placeholder.empty();
            $placeholder.html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
        }
    });
}
$(document).ready(function () {
    $(function () {
        $("#MembershipNumber").change(function () {
            var memNo = $(this).val();
            if(memNo == ""){
                $("#lblPolicyHolder").empty();
                $("#lblMembershipNo").empty();
                $("#lblBeneficiaries").empty();
            }
            else{
                $.getJSON('@Url.Action("GetMemberDetails", "MemberPolicy")', { membershipNo: memNo, Type: 1 },
                        function (data) {
                            var select = $("#MainMemberFullName");
                            select.empty();

                            $.each(data, function (index, item) {
                                if (index == 0) {
                                    $("#lblPolicyHolder").empty();
                                    $("#lblPolicyHolder").append(item.FirstName + " " + item.LastName);
                                    $("#lblMembershipNo").empty();
                                    $("#lblMembershipNo").append(item.MembershipNumber);
                                }
                                else {
                                    $("#lblBeneficiaries").empty();
                                    $("#lblBeneficiaries").append(item.NoOfBeneficiaries + " member(s)");
                                }
                            });
                        });
            }

        });
    });
});

function AllocatePolicyToMemberClick(sender, e) {
    var pHolder = $('#lblPolicyHolder').text(), memNo = $('#lblMembershipNo').text(), benefic = $('#lblBeneficiaries').text(),
    maxBenefic = $('#lblMaxBeneficiaries').text(), pName = $('#lblPolicyName').text(), pDesc = $('#lblPolicyDesc').text(),
    waitngP = $('#lblWaitingPeriod').text(), benefits = $('#lblBenefitId').text(), monthlyFee = $('#lblMonthlyFee').text(),
    adminFees = $('#lblAdminFee').text(), polId = $('#lblPolicyId').text();
    $(window).scrollTop(0);
    //alert(benefits);
    $("#btnSpinner").show();
    if (pHolder != "" && memNo != "" && benefic != "" && maxBenefic != "" && pName != "" && pDesc != "" && waitngP != "" && benefits != "" && monthlyFee != "" && adminFees != "" && polId != "" ) {
        $.ajax({
            cache: false,
            type: "GET",
            data: { MemNumber: memNo, PolID: polId, NoOfBenefic: benefic, AdminFee: adminFees, MonthlyFee: monthlyFee, WaitingPeriod: waitngP, Benefits: benefits },
            url: '@Url.Action("AllocatePolicyToMember", "MemberPolicy")',
            success: function (data) {
                SuccessAlert(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
            }
        });
    }
    else {
        $('#btnSpinner').hide();
        $.notify({
            title: '<strong>Error!</strong>',
            message: 'Please select all options required to allocate a policy.'
        }, {
            type: 'danger'
        });
    }
    function SuccessAlert(data) {
        if (data == 1) {
            $("option[value='" + memNo + "']").remove();
            $('#lblPolicyHolder').text(""); $('#lblMembershipNo').text(""); $('#lblBeneficiaries').text(""); $('#lblMaxBeneficiaries').text("");
            $('#lblPolicyName').text(""); $('#lblPolicyDesc').text(""); $('#lblWaitingPeriod').text(""); $('#lblBenefitId').text("");
            $('#lblMonthlyFee').text(""); $('#lblAdminFee').text(""); $('#adminFee').val(""); $('#lblPolicyId').text("");
            $('#lblBenefits').text("");
            $('#btnSpinner').hide();
            $.notify({
                title: '<strong>Success!</strong>',
                message: 'Member has been allocated a policy successfully.'
            }, {
                type: 'success'
            });
        }
        else {
            $('#btnSpinner').hide();
            $.notify({
                title: '<strong>Error!</strong>',
                message: 'Something went wrong please try again.'
            }, {
                type: 'danger'
            });
        }
    }
}
