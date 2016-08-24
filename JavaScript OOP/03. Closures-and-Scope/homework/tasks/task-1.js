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
			categories = [],
			categoryID = 1;

		function listBooks() {
			return books;
		}

		function addBook(book) {
			book.ID = books.length + 1;
			books.push(book);

			book.category.ID = ++categoryID;

			if (containsID(book.category)) {
				categories.push(book.category);
			}

			return book;
		}

		function containsID(category) {
			var len = categories.length;

			for (var i = 0; i < len; i += 1) {
				if (category.ID === categories[i].ID) {
					return false;
				}
			}
			return true;
		}

		function listCategories() {

			categories.sort(function (a, b) {
				return a.ID - b.ID;
			});

			return categories;
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
