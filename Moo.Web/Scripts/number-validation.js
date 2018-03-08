$(window).ready(function () {
    $('#number').on('keyup', function () {
        let value = $('#number').val();
        let length = value.length;

        let digistAreUnique =
            numberOfDigits(value, value[0]) === 1
            && numberOfDigits(value, value[1]) === 1
            && numberOfDigits(value, value[2]) === 1
            && numberOfDigits(value, value[3]) === 1;

        if (value.match(/[1-9][0-9]{3}/) && digistAreUnique) {
            $('#submit')
                .removeClass('disabled')
                .attr('type', 'submit');
        } else {
            $('#submit')
                .addClass('disabled')
                .attr('type', 'button');
        }
    });
});

function numberOfDigits(string, digits) {
    let count = 0;
    let index = string.indexOf(digits);
    while (index !== -1) {
        string = string.slice(index + 1);
        count++;
        index = string.indexOf(digits);
    }

    return count;
}