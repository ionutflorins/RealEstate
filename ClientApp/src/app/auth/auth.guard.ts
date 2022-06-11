import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../Service/user.service';



@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {


constructor(private router: Router, private userService : UserService) {
  
}


  canActivate(
    
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
   if (localStorage.getItem('token') != null){
      let roles = next.data['permittedRoles'] as Array<string>;
      if(roles){
        if(this.userService.roleMatch(roles)) return true;
        else
        {
          this.router.navigate(['/forbidden']);
          return false
        }
      }
      return true;
   }
    else
    this.router.navigate(['/user/login']);
    return false;
  }

}
