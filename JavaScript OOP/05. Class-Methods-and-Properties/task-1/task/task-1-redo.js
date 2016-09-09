'use strict';

class ListNode {
    constructor(value) {
        this.data = value;
        this.next = null;
    }

    get data() {
        return this._data;
    }
    set data(value) {
        this._data = value;
    }

    get next() {
        return this._next;
    }
    set next(value) {
        this._next = value;
    }
}

class LinkedList {
    constructor() {
        this._length = 0;
        this._first = null;
    }

    get length() {
        let length = this.toArray().length;
        return length;
    }

    get first() {
        return this.at(0);
    }

    get last() {
        return this.at(this.length - 1);
    }

    append(...items) {
        var currentItem;

        for (let item of items) {
            let listNode = new ListNode(item);

            if (!this._first) {
                this._first = listNode;

            } else {
                currentItem = this._first;

                while (currentItem.next) {
                    currentItem = currentItem.next;
                }
                currentItem.next = listNode;
            }
        }
        return this;
    }

    prepend(...items) {
        var currentItem,
            firstItem;

        if (!this._first) {
            this.append(...items);
            return;
        }

        for (let item of items) {
            let listNode = new ListNode(item);

            if (!currentItem) {
                currentItem = listNode;
                firstItem = currentItem;
            } else {
                currentItem.next = listNode;
                currentItem = currentItem.next;
            }
        }
        currentItem.next = this._first;
        this._first = firstItem;
        
        return this;
    }

    insert(index, ...values) {

        if (index === 0) {
            this.prepend(...values);

        } else if (index === this.length) {
            this.append(...values);

        } else {
            let prevElement = this._getElementAt(index - 1),
                currentElement = this._getElementAt(index);

            for (let item of values) {
                let listNode = new ListNode(item);

                prevElement.next = listNode;
                prevElement = prevElement.next;
            }

            prevElement.next = currentElement;
        }
        return this;
    }

    at(index, value) {
        let elementAtIndex = this._getElementAt(index);

        if (value || value === 0) {
            elementAtIndex.data = value;
        }

        return elementAtIndex.data;
    }

    removeAt(index) {
        let prevElement = this._getElementAt(index - 1),
            currentElement = this._getElementAt(index);

        if (index === 0) {
            this._first = currentElement.next;
        } else {
            prevElement.next = currentElement.next;
        }

        return currentElement.data;
    }

    _getElementAt(index) {
        let currentElement = this._first;

        for (var i = 0; i < index; i += 1) {
            currentElement = currentElement.next;
        }

        return currentElement;
    }

    toArray() {
        let currentElement = this._first,
            elementArray = [];

        while (currentElement.next) {
            elementArray.push(currentElement.data);
            currentElement = currentElement.next;
        }

        elementArray.push(currentElement.data);
        return elementArray;
    }

    toString() {
        let stringArray = this.toArray().join(' -> ');
        return stringArray;
    }


    *[Symbol.iterator]() {
        let currentElement = this._first;

        while (currentElement) {
            yield currentElement.data;
            currentElement = currentElement.next;
        }
    }
}

module.exports = LinkedList;