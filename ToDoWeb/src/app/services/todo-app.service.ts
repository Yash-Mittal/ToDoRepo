import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TodoItem } from '../models/todo-item.model';

@Injectable({
  providedIn: 'root'
})
export class TodoAppService {
  readonly baseURL = "http://localhost:36476/api/ToDoModels";
  todos: TodoItem[]=[];

  constructor(private http: HttpClient) { }

  todoData: TodoItem = new TodoItem();

  addTodo(todo: TodoItem) {
    return this.http.post(this.baseURL, todo, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  putToDoItem(todo: TodoItem) {
    console.log(todo.itemId);
    console.log("Hello");
    console.log(todo);
    return this.http.put(`${this.baseURL}/${todo.itemId}`, todo, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  deleteTodoById(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  getAllTodos() {
    this.http.get(this.baseURL)
    .toPromise()
    .then(res => {
      let data = res as TodoItem[];
      if(data.length>0){
      this.todos = data;
      }
      else{
        this.todos =[];
      }
    });
  }

}
