import {ResolveFn} from '@angular/router';
import { User } from '../../shared/models/user';
import { inject } from '@angular/core';
import { UsersService } from '../../users/users.service';

export const userDetailedResolver: ResolveFn<User> = (route, state) => {
  const userService = inject(UsersService);
  return userService.getUser(route.paramMap.get('username')!)
};