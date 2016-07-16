function solve(args) {
    var result = "",
        text = args[0],
        offset = +args[1],
        alphabet = 'abcdefghijklmnopqrstuvwxyz',
        charMet = "",
        counter = 1,
        substring = text[0],
        encrText = "",
        cypher = "",
        oddAndEvenNumbers = [],
        oddProduct = 1,
        evenSum = 0;

    // Compressing the text
    for (var i = 0; i < text.length; i += 1) {

        charMet = text[i];
        if (charMet === text[i + 1]) {
            counter++;
            substring += text[i + 1];
        }
        else {
            if (counter > 2) {
                result += counter + substring[0];
            }
            else {
                result += substring;
            }
            counter = 1;
            substring = text[i + 1];
        }
    }

    // Encrypting the result
    function isLetter(str) {
        return str.length === 1 && str.match(/[a-z]/i);
    }

    substring = alphabet.substring(alphabet.length - offset, alphabet.length);
    cypher = alphabet;
    cypher = cypher.replace(substring, '');
    cypher = substring + cypher;

    for (i = 0; i < result.length; i += 1) {
        if (isLetter(result[i])) {
            encrText += cypher.charCodeAt(result.charCodeAt(i) - alphabet.charCodeAt(0)) ^ result.charCodeAt(i);
        }
        else {
            encrText += result[i];
        }
    }
// Summing odd/even numbers
    oddAndEvenNumbers = encrText.split('').map(Number);

    for(i = 0; i < oddAndEvenNumbers.length; i += 1) {
        if (oddAndEvenNumbers[i] % 2 === 0) {
            evenSum += oddAndEvenNumbers[i];
        }
        else if (oddAndEvenNumbers[i] % 2 === 1) {
            oddProduct *= oddAndEvenNumbers[i];
        }
    }

    console.log(evenSum);
    console.log(oddProduct);
}


solve(['aaaabbbccccaa', '3']);