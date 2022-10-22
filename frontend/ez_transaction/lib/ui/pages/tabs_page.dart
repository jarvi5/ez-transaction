import 'package:ez_transaction/ui/pages/home_page.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';

class TabsPage extends StatefulWidget {
  final int index;
  TabsPage({Key? key, required this.index}) : super(key: key) {
    assert(index != -1);
  }

  @override
  _TabsPageState createState() => _TabsPageState();
}

class _TabsPageState extends State<TabsPage>
    with TickerProviderStateMixin, AutomaticKeepAliveClientMixin {
  late final TabController _controller;

  @override
  void initState() {
    super.initState();
    _controller = TabController(
      length: 2,
      vsync: this,
      initialIndex: widget.index,
    );
  }

  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  @override
  void didUpdateWidget(TabsPage oldWidget) {
    super.didUpdateWidget(oldWidget);
    _controller.index = widget.index;
  }

  @override
  Widget build(BuildContext context) {
    super.build(context);
    return Scaffold(
      appBar: AppBar(
        title: Text(_title(context)),
      ),
      body: TabBarView(
        controller: _controller,
        children: const [HomePage(), Center(child: Text('Settings'))],
      ),
      bottomNavigationBar: BottomNavigationBar(
        items: const [
          BottomNavigationBarItem(label: 'Home', icon: Icon(Icons.home)),
          BottomNavigationBarItem(label: 'Settings', icon: Icon(Icons.settings))
        ],
        currentIndex: widget.index,
        onTap: _onTap,
      ),
    );
  }

  void _onTap(int index) {
    switch (index) {
      case 1:
        context.go('/settings');
        break;
      default:
        context.go('/home');
    }
  }

  String _title(BuildContext context) =>
      (context as Element).findAncestorWidgetOfExactType<MaterialApp>()!.title;

  @override
  bool get wantKeepAlive => true;
}
