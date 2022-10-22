import 'package:ez_transaction/ui/pages/tabs_page.dart';
import 'package:go_router/go_router.dart';

final router = GoRouter(
  routes: [
    GoRoute(
      path: '/',
      redirect: (context, state) => '/home',
    ),
    GoRoute(
      path: '/home',
      pageBuilder: (context, state) => NoTransitionPage(
        child: TabsPage(
          key: state.pageKey,
          index: 0,
        ),
      ),
    ),
    GoRoute(
      path: '/settings',
      pageBuilder: (context, state) => NoTransitionPage(
        child: TabsPage(
          key: state.pageKey,
          index: 1,
        ),
      ),
    ),
  ],
);
