import { Component, OnInit } from '@angular/core';
import { TodoItem } from '../models/todo-item.model';
import { TodoAppService } from '../services/todo-app.service';

@Component({
  selector: 'app-todo-items',
  templateUrl: './todo-items.component.html',
  styles: [
  ]
})
export class TodoItemsComponent implements OnInit {
  ngOnInit(): void {
    this.gettodos();
  }

  newTodo: TodoItem = new TodoItem();

  constructor(public todoDataService: TodoAppService) {
  }

  addTodo() {
    this.todoDataService.addTodo(this.newTodo).subscribe(
      res => {
        this.gettodos();
        this.newTodo = new TodoItem();
      },
      err => { console.log(err); }
    );
    // this.todoDataService.addTodo(this.newTodo);
    // this.newTodo = new TodoItem();
  }

  toggleTodoComplete(todo: TodoItem) {
    todo.itemStatus = !todo.itemStatus;
    this.todoDataService.putToDoItem(todo).subscribe(
      res => {
        this.gettodos();
      },
      err => { console.log(err); }
    );
  }

  removeTodo(todo: TodoItem) {
    this.todoDataService.deleteTodoById(todo.itemId)
      .subscribe( res => {
        this.gettodos();
      },
      err => {
        console.log(err);
      })
    //this.todoDataService.deleteTodoById(todo.id);
  }

  gettodos() {
     this.todoDataService.getAllTodos();
  }

}
