import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  larguraImg: number = 150;
  margemImg:number = 2;
  exibirImg = true;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  alterarImg(){
    this.exibirImg = !this.exibirImg;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/Eventos/').subscribe(
      response => this.eventos = response,
      error => console.log(error),
    );

  }
}
