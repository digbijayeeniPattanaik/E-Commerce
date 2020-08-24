import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-text-error',
  templateUrl: './text-error.component.html',
  styleUrls: ['./text-error.component.scss']
})
export class TextErrorComponent implements OnInit {

  baseUrl = environment.apiUrl;
  constructor(private http : HttpClient) { }

  ngOnInit(): void {
  }

  get404Error()
  {
    this.http.get(this.baseUrl + 'products/42').subscribe((response) => {
    console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get500Error()
  {
    this.http.get(this.baseUrl + 'buggy/servererror').subscribe((response) => {
    console.log(response);
    }, error => {
      console.log(error);
    });
  }
  get400Error()
  {
    this.http.get(this.baseUrl + 'buggy/badrequest').subscribe((response) => {
    console.log(response);
    }, error => {
      console.log(error);
    });
  }
  get400ValidationError()
  {
    this.http.get(this.baseUrl + 'product/fortytwo').subscribe((response) => {
    console.log(response);
    }, error => {
      console.log(error);
    });
  }
}
