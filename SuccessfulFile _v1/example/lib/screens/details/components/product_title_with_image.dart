import 'package:flutter/material.dart';
import 'package:flutter_unity_widget_example/screens/models/product.dart';

import '../../constants.dart';

class ProductTitleWithImage extends StatelessWidget {
  final String productToSpawn;
  const ProductTitleWithImage({
    Key key,
    @required this.product, this.productToSpawn,
  }) : super(key: key);

  final Product product;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: kDefaultPadding),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          Text(
            "Koleksi Dekorasi Terbaiq",
            style: TextStyle(color: Colors.white),
          ),
          Text(product.title,
              style: Theme.of(context)
                  .textTheme
                  .headline
                  .copyWith(color: Colors.white, fontWeight: FontWeight.bold)),
          SizedBox(
            width: kDefaultPadding,
          ),
          Row(
            children: <Widget>[
              RichText(
                text: TextSpan(children: [
                  TextSpan(text: "Price\n"),
                  TextSpan(
                      text: "\$${product.price}",
                      style: Theme.of(context).textTheme.headline.copyWith(
                          color: Colors.white, fontWeight: FontWeight.bold))
                ]),
              ),
              SizedBox(
                width: kDefaultPadding * 2,
              ),
              Expanded(
                child: Hero(
                  tag: "${product.id}",
                  child: Image.asset(
                    product.image,
                    fit: BoxFit.fill,
                  ),
                ),
              )
            ],
          )
        ],
      ),
    );
  }
}
