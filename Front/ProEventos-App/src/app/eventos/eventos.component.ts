import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  larguraImg: number = 150;
  margemImg:number = 2;
  exibirImg = true;
  private _filtrolista: string = '';

  public get filtrolista(): string {
    return this._filtrolista;
  }

  public set filtrolista(value){
    this._filtrolista = value;
    this.eventosFiltrados = this.filtrolista ?
                   this.filtrarEventos(this.filtrolista) :
                   this.eventos;
  }

  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string }) =>
       evento.tema.toLowerCase().indexOf(filtrarPor) !== -1 ||
       evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  alterarImg(){
    this.exibirImg = !this.exibirImg;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/Eventos/').subscribe(
      response => {
          this.eventos = response;
          this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );

  }
}
