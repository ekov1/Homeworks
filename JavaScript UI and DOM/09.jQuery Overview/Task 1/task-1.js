/* 
Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:   
  * The UL must have a class `items-list`
  * Each of the LIs must:
    * have a class `list-item`
    * content "List item #INDEX"
      * The indexes are zero-based
  * If the provided selector does not select anything, do nothing
  * Throws if
    * COUNT is a `Number`, but is less than 1
    * COUNT is **missing**, or **not convertible** to `Number`
      * _Example:_
        * Valid COUNT values:
          * 1, 2, 3, '1', '4', '1123'
        * Invalid COUNT values:
          * '123px' 'John', {}, [] 
*/

function solve() {
  return function (selector, count) {

    if (!selector || typeof selector !== 'string') {
      throw Error();
    }
    if (typeof count !== 'number' || count < 1) {
      throw Error();
    }

    var element = $(selector),
      ul = $('<ul />').addClass('items-list'),
      li, i;

    if (!element) {
      return;
    }

    for (i = 0; i < count; i += 1) {

      li = $('<li />')
        .addClass('list-item')
        .text('List item #' + i);

      li.appendTo(ul);
    }

    ul.appendTo(element);
  };
}

module.exports = solve;
