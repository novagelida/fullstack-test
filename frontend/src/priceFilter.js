export const priceFilter = function(value) {
    // NOTE: This just work under the assumption we do not process more than 4 digits values
    var strValue = value.toString();

    if (strValue.length > 3)
    {
        strValue = strValue[0]+'.'+strValue.slice(1, strValue.length);
    }

    return strValue + ",00 €";
}