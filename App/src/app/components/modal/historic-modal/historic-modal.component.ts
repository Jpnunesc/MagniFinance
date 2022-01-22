import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-historic-modal',
  templateUrl: './historic-modal.component.html',
  styleUrls: ['./historic-modal.component.css']
})
export class HistoricModalComponent implements OnInit {
  @Input() opem: boolean = false;
  @Input() id: any;
  @Input() data: any = [];
  @Output() closed = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }

  fechar() {
    this.closed.emit(false);
  }
  tipo(item: Number): string {
    return item == 1 ? 'Debito'
      : item == 2 ? 'Boleto'
        : item == 3 ? 'Financiamento'
          : item == 4 ? 'Credito'
            : item == 5 ? 'Recebimento Emprestimo'
              : item == 6 ? 'Vendas'
                : item == 7 ? 'Recebimento TED'
                  : item == 8 ? 'Recebimento DOC'
                    : item == 9 ? 'Aluguel' : '';
  }
  cpf(valorFormatado) {
    valorFormatado = valorFormatado
      .padStart(11, '0')
      .substr(0, 11)
      .replace(/[^0-9]/, '')
      .replace(
        /(\d{3})(\d{3})(\d{3})(\d{2})/,
        '$1.$2.$3-$4'
      );
    return valorFormatado;
  }
}
