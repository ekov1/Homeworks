
class listNode {
    constructor(value) {
        this._data = value;
        this._next = null;
    }

    get next() {
        return this._next;
    }

    set next(value) {
        this._next = value;
    }

    get data() {
        return this._data;
    }
    set data(value) {
        this._data = value;
    }
}

class LinkedList {
    constructor() {
        this._length = 0;
        this._firstItem = null;
    }

    get first() {
        return this._firstItem;
    }
    set first(value) {
        this._firstItem = value;
    }

    get last() {

    }

    get length() {
        return this._length;
    }
    set length(value) {
        this._length = value;
    }

    append(values) {
        var currentItem;

        for (var name of arguments) {

            var itemToAppend = new listNode(name);

            if (!this.first) {
                this.first = itemToAppend;
            } else {
                currentItem = this.first;

                while (currentItem.next) {
                    currentItem = currentItem.next;
                }

                currentItem.next = itemToAppend;
            }

            this._length += 1;
        }
    }

    prepend(values) {
        for (var value of arguments) {

            var itemToAppend = new listNode(value);

            if (this.first === null) {
                this.first = item;
            } else {
                 itemToAppend.next = this.first;
                 this.first = itemToAppend; 
            }

            this.length += 1;
        }
    }
}

var list = new LinkedList();

list.append(1, 2, 3, 4);
list.prepend(7);

console.log(list);
// console.log(list.first.data);
// console.log(list.first.next.data);
// console.log(list.first.next.next.data);
// console.log(list.first.next.next.next.data);

//module.exports = LinkedList;