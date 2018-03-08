$(window).ready(function () {
    validateForm(true);
    $('#Guess, #Cows, #Bulls, #opponent-number-slots-1, #opponent-number-slots-2, #opponent-number-slots-3, #opponent-number-slots-4')
        .on('keyup', function () {
            validateForm();
        });
});

function validateForm(disabled) {
    let guessValue = $('#Guess').val().length;
    let cowsValue = $('#Cows').val().length;
    let bullsValue = $('#Bulls').val().length;
    let slot1Length = $('#opponent-number-slots-1').val().length;
    let slot2Length = $('#opponent-number-slots-2').val().length;
    let slot3Length = $('#opponent-number-slots-3').val().length;
    let slot4Length = $('#opponent-number-slots-4').val().length;

    if (guessValue == 4 && cowsValue == bullsValue == 1 && slot1Length < 2 && slot2Length < 2 && slot3Length < 2 && slot4Length < 2) {
        $('#submit')
            .removeClass('disabled')
            .attr('type', 'submit');
    } else {
        $('#submit')
            .addClass('disabled')
            .attr('type', 'button');
    }
}