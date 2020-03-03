(function () {
	$('.mobile-menu').on('click', function () {
		$('.hamburger-menu').toggleClass('animate');
	});

})();

var TeamDetailPostBackURL = '/Home/LoanForm';
$(function () {
	$(".show").on("click", function (e) {
		//debugger;
		var $buttonClicked = $(this);
		var id = $buttonClicked.attr('data-id');
		var options = { "backdrop": "static", keyboard: true };

		$.ajax({
			type: "GET",
			url: TeamDetailPostBackURL,
			contentType: "application/json; charset=utf-8",
			data: { "Id": id },
			datatype: "json",
			success: function (data) {

				$(data).insertAfter(".mask");
				console.log(data);
				
				$(".mask").addClass("active");

			},
			error: function () {
				alert("Dynamic content load failed.");
			}
		});  

		
	});


	// Function for close the Modal

	function closeModal() {
		$(".mask").removeClass("active");
	}

	// Call the closeModal function on the clicks/keyboard

	$(".close, .mask").on("click", function (e) {
		closeModal();
	});

	$(document).keyup(function (e) {
		if (e.keyCode == 27) {
			closeModal();
		}
	});
});  