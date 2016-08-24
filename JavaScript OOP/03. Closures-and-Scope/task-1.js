var library = (function () {
    var category,
        id = 0,
        books = [],
        categories = [];


    function addNewBookToCategory(book, category) {
        book.id = ++id;

        if (!category) {
            category = [];
        }

        category.push(book);
        // books.push(book);
        return category;
    }

    function listAllBooks() {
        if (!books) {
            return null;
        }

// should add function to sort with other contidions
        books.sort(function (a, b) {
            return a.id - b.id;
        });
        return books;
    }

    function listAllCategories() {

    }

})();