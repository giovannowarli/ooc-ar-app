import 'package:flutter/material.dart';
import 'package:flutter_unity_widget_example/screens/models/product.dart';


import '../../constants.dart';


class ColorAndSize extends StatelessWidget {
  const ColorAndSize({
    Key key,
    @required this.product,
  }) : super(key: key);

  final Product product;

  @override
  Widget build(BuildContext context) {
    return Row(
      children: <Widget>[
        Expanded(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Text('Color'),
              Row(
                children: <Widget>[
                  ColorDot(
                    color: Color(0xFF654321),
                    isSelected: true,
                  ),
                  ColorDot(color: Color(0xFFF8C078)),
                ],
              )
            ],
          ),
        ),
        Expanded(
          child: RichText(
            text: TextSpan(
              style: TextStyle(color: kTextColor),
              children: [
                TextSpan(text: "Size\n"),
                TextSpan(
                    text: product.size,
                    style: Theme.of(context)
                        .textTheme
                        .headline
                        .copyWith(
                            fontWeight: FontWeight.bold))
              ],
            ),
          ),
        )
      ],
    );
  }
}

class ColorDot extends StatelessWidget {
  final Color color;
  final bool isSelected;

  const ColorDot({
    Key key,
    this.color,
    this.isSelected = false,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
        margin: EdgeInsets.only(
            top: kDefaultPadding / 4, right: kDefaultPadding / 2),
        padding: EdgeInsets.all(2.5),
        width: 24,
        height: 24,
        decoration: BoxDecoration(
          border: Border.all(color: isSelected ? color : Colors.transparent),
          shape: BoxShape.circle,
        ),
        child: DecoratedBox(
            decoration: BoxDecoration(color: color, shape: BoxShape.circle)));
  }
}
