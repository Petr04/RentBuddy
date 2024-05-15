import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CodeInputModule } from 'angular-code-input';


@Component({
  selector: 'app-verification-page',
  standalone: true,
  imports: [RouterLink, CodeInputModule],
  templateUrl: './verification-page.component.html',
  styleUrl: './verification-page.component.css'
})
export class VerificationPageComponent {

  onCodeChanged(code: string) {
  }

  // this called only if user entered full code
  onCodeCompleted(code: string) {
  }
}

