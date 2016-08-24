/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	var library = (function () {
		var books = [],
			categories = [];

		function listBooks(obj) {
			var sortedBooks;

			if (books.length === 0) {
				return books;
			}

			sortedBooks = books.sort(function (a, b) {
				return a.ID - b.ID;
			});

			if (obj) {

				for (var prop in Object.keys(obj)) {
					sortedBooks = sortedBooks.filter((c) => c[prop] === obj[prop]);
				}
			}


			return sortedBooks;
		}

		function addBook(book) {
			book.ID = books.length + 1;

			if (!isBookInfoValid(book)) {
				throw new Error('Invalid book info, cannot add book!');
			}
			books.push(book);

			if (!containsCategory(book)) {
				var category = {};
				category.title = book.category;
				category.ID = categories.length + 1;

				categories.push(category);
			}

			return book;
		}

		function containsCategory(book) {
			var len = categories.length;

			for (var i = 0; i < len; i += 1) {
				if (book.category === categories[i].title) {
					return true;
				}
			}
			return false;
		}

		function listCategories() {

			var sortedCategories = categories.sort(function (a, b) {
				return a.ID - b.ID;
			}).map((c) => c.title);

			return sortedCategories;
		}

		function isBookInfoValid(book) {
			var len = books.length;

			if ((book.isbn.length !== 10 && book.isbn.length !== 13) ||
				book.title.length < 2 || book.title.length > 100 ||
				book.category.length < 2 || book.category.length > 100 ||
				!book.author) {
				return false;
			}

			for (var i = 0; i < len; i += 1) {
				if (book.title === books[i].title || book.isbn === books[i].isbn) {
					return false;
				}
			}
			return true;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}
module.exports = solve;
