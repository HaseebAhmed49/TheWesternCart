import { ResolveFn } from '@angular/router';
import { UsersService } from '../../users/users.service';
import { inject } from '@angular/core';
import { User } from '../../shared/models/user';

export const userDetailedResolver: ResolveFn<User> = (route, state) => {
  const userService = inject(UsersService);
  return userService.getUser(route.paramMap.get('username')!)
};
