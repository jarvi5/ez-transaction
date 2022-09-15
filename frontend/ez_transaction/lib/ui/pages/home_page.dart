import 'package:barcode_scan2/barcode_scan2.dart';
import 'package:ez_transaction/state/qr_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Center(
          child: Column(
            children: [
              Consumer(
                builder: (_, ref, __) => TextButton(
                  onPressed: () async {
                    var result = await BarcodeScanner.scan();
                    ref.read(qrProvider.notifier).setState(result.rawContent);
                  },
                  child: const Text('Scan'),
                ),
              ),
              Consumer(builder: (_, ref, __) {
                final qrState = ref.watch(qrProvider);
                return Text(qrState);
              }),
            ],
          ),
        ),
      ),
    );
  }
}
