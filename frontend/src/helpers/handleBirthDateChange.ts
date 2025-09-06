
export function handleBirthDateChange(event: any, handleChange: (any)) {
    let formattedNumber = event.target.value.replace(/\D/g, ''); // Remove todos os caracteres não numéricos

    if (formattedNumber.length > 8) {
        return;
    }
    if (formattedNumber.length > 2 && formattedNumber.length <= 4) {
        formattedNumber = `${formattedNumber.substring(0, 2)}/${formattedNumber.substring(2)}`;
    }
    else if (formattedNumber.length > 4) {
        formattedNumber = `${formattedNumber.substring(0, 2)}/${formattedNumber.substring(2, 4)}/${formattedNumber.substring(4)}`;
    }

    event.target.value = formattedNumber;

    handleChange(event);
}
