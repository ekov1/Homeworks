var library = (function () {
    var category,
        bookId = 1,
        categoryId = 1,
        books = [],
        categories = [];


    function addNewBookToCategory(book, category) {
        book.id = ++bookId;

        if (!category) {
            category = [];
            category.id = ++categoryId;
            categories.push(category);
        }

        category.push(book);
        // books.push(book);
        return category;
    }

    function validateBookInfo(book) {

        var bookTitleLength = book.length,
            bookCategoryLength = book.category.length;

        if (bookTitleLength < 2 || bookTitleLength > 100 ||
            bookCategoryLength < 2 || bookCategoryLength > 100 ||
            book.author.length === 0 ||
            !isUnique(book) ||
            (book.isbn.length !== 10 && book.isbn.length !== 13)) {
                
            throw Error('Invalid book info! Will not add book');
        }
    }

    function isUnique(obj) {

        for (var i = 0; i < books.length; i += 1) {
            if (obj.title === books[i].title || obj.isbn === books[i].isbn) {
                return false;
            }
        }
        return true;
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

        categories.sort(function (a, b) {
            return a.id - b.id;
        });

        return categories;
    }

    return {
        addBook: addNewBookToCategory,
        listBooks: listAllBooks,
        listCategories: listAllCategories
    };

})();

