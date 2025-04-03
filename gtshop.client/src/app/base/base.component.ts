import { Component, Injector, OnInit } from '@angular/core';
import { FormGroup, AbstractControl } from '@angular/forms';

@Component({
  template:''
})
export class BaseComponent {
 

  hideElements(): void {
    let navbarElements = document.getElementsByTagName("app-navbar")[0] as HTMLElement;
    let videoContainer = navbarElements.getElementsByClassName("navbar-videoContainer")[0] as HTMLElement;
    let footer = document.getElementById("main-footer")! as HTMLElement;
    let navbar = document.getElementById("main-navbar")! as HTMLElement;

    navbar.style.display = "none";
    videoContainer.style.display = "none";
    footer.style.display = "none";
  };

  showElements(): void {
    let navbarElements = document.getElementsByTagName("app-navbar")[0] as HTMLElement;
    let videoContainer = navbarElements.getElementsByClassName("navbar-videoContainer")[0] as HTMLElement;
    let footer = document.getElementById("main-footer")! as HTMLElement;
    let navbar = document.getElementById("main-navbar")! as HTMLElement;

    navbar.style.display = "block";
    videoContainer.style.display = "block";
    footer.style.display = "block";
  }

  form!: FormGroup;

  getErrors(
    control: AbstractControl,
    displayName: string,
    customMessages: { [key: string]: string } | null = null
  ): string[] {
    var errors: string[] = [];
    Object.keys(control.errors || {}).forEach((key) => {
      switch (key) {
        case 'required':
          errors.push(`${displayName} ${customMessages?.[key] ?? "is required."}`);
          break;
        case 'pattern':
          errors.push(`${displayName} ${customMessages?.[key] ?? "contains invalid characters."}`);
          break;
        case 'isDupeField':
          errors.push(`${displayName} ${customMessages?.[key] ?? "already exists: please choose another."}`);
          break;
        default:
          errors.push(`${displayName} is invalid.`);
          break;
      }
    });
    return errors;
  }

  constructor() { }
}
