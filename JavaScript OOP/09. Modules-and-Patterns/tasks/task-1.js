/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
  var Course = (function () {

    function init(title, presentations) {
      validateTitle(title);
      this.courseTitle = title;

      if (presentations.length === 0) {
        throw new Error('No presentations in course!');
      }

      if (!arePresentationTitlesValid(presentations)) {
        throw new Error('Presentation titles are not valid!');
      }

      this.uniqueID = 0;
      this.courseStudents = [];
      this.homeworks = [];
      this.examResults = [];
      this.coursePresentations = presentations;
    }

    function validateTitle(title) {
      if (!title) {
        throw new Error('Title must have length of at least one symbol!');
      }

      if (title !== title.trim()) {
        throw new Error('Title cannot contain spaces at start or end!');
      }

      let replacedMultipleSpacesTitle = title.replace(/\s\s+/g, ' ');

      if (title !== replacedMultipleSpacesTitle) {
        throw new Error('Title cannot contain multiple consecutive spaces!');
      }
    }

    function arePresentationTitlesValid(presentations) {

      presentations.forEach(function (title) {
        if (!validateTitle(title)) {
          return false;
        }
      });
      return true;
    }

    function addStudent(name) {
      let student = {},
        studentNames = name.split(' ');

      validateStudentNames(studentNames);

      student.firstname = studentNames[0];
      student.lastname = studentNames[1];
      student.id = ++this.uniqueID;

      this.courseStudents.push(student);
      return this.uniqueID;
    }

    function validateStudentNames(studentNames) {
      if (studentNames.length !== 2) {
        throw new Error('Invalid name format!');
      }

      let areFirstLettersUppercase = studentNames[0][0].toUpperCase() === studentNames[0][0] &&
        studentNames[1][0].toUpperCase() === studentNames[1][0];

      if (!areFirstLettersUppercase) {
        throw new Error('First letters of student names are not UpperCase!');
      }

      let areOtherLettersLowerCase = areRemainingLettersLowerCase(studentNames[0]) &&
        areRemainingLettersLowerCase(studentNames[1]);

      if (!areOtherLettersLowerCase) {
        throw new Error('All letters except the first should be lower cased!');
      }

    }

    function areRemainingLettersLowerCase(name) {
      let len = name.length;

      for (var i = 1; i < len; i += 1) {
        if (name[i].toLowerCase() !== name[i]) {
          return false;
        }
      }
      return true;
    }

    function getAllStudents() {
      let students = this.courseStudents.splice(0);

      return students;
    }

    function submitHomework(studentID, homeworkID) {
      let isStudentIDValid = studentID > 0 && studentID <= this.courseStudents.length && studentID % 1 === 0;
      let isHomeworkIDValid = homeworkID > 0 && homeworkID <= this.coursePresentations.length;

      if (!isStudentIDValid || !isHomeworkIDValid) {
        throw new Error('Wrong ID provided! Try again!');
      }
    }

    function pushExamResults(results) {

      for (let student of results) {
        let isStudentIDValid = student.StudentID > 0 && student.StudentID <= this.courseStudents.length;
        let isScoreValid = student.score && typeof student.score === 'number';

        if (!isStudentIDValid) {
          throw new Error('Invalid student ID in exam results');
        }

        if (!isScoreValid) {
          throw new Error('Student exam score is not valid!');
        }
      }

      if (hasDuplicateStudentID(results)) {
        throw new Error('Someone is trying to cheat!');
      }

      this.examResults = results;
    }

    function hasDuplicateStudentID(results) {
      results = results.sort((a, b) => a.StudentID - b.StudentID);

      for (var i = 0; i < results.length - 1; i += 1) {
        if (results[i].StudentID === results[i + 1].StudentID) {
          return true;
        }
      }

      return false;
    }

    function getTopStudents() {

    }

    return {
      init: init,
      addStudent: addStudent,
      getAllStudents: getAllStudents,
      submitHomework: submitHomework,
      pushExamResults: pushExamResults,
      getTopStudents: getTopStudents
    }
  } ());
  return Course;
}

module.exports = solve;

// var course = Course.init('Hello', ['Maths']);

// var id = Course.addStudent('John Doe');
// Course.submitHomework(id + 5, 1);