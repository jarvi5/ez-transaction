import 'package:flutter_riverpod/flutter_riverpod.dart';

final qrProvider = StateNotifierProvider<QrNotifer, String>((ref) {
  return QrNotifer();
});

class QrNotifer extends StateNotifier<String> {
  QrNotifer() : super('');

  setState(String value) {
    state = value;
  }
}
