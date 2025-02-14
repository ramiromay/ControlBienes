using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Utils
{
	public static class BusExpressionUtils
	{
		public static Expression<Func<T, bool>> UCombinarExpression<T>(
			List<Expression<Func<T, bool>>> expressions)
		{
			if (expressions == null || !expressions.Any())
				return e => true;

			// Comienza con la primera expresión
			var combined = expressions.First();

			// Combina las expresiones restantes con "AndAlso"
			foreach (var expression in expressions.Skip(1))
			{
				combined = combined.And(expression);
			}

			return combined;
		}

		// Método de extensión para combinar dos expresiones con "AndAlso"
		public static Expression<Func<T, bool>> And<T>(
			this Expression<Func<T, bool>> expr1,
			Expression<Func<T, bool>> expr2)
		{
			var parameter = Expression.Parameter(typeof(T));

			// Reemplazar los parámetros en ambas expresiones
			var left = new ReplaceParameterVisitor(expr1.Parameters[0], parameter).Visit(expr1.Body);
			var right = new ReplaceParameterVisitor(expr2.Parameters[0], parameter).Visit(expr2.Body);

			// Combinar las expresiones con "AndAlso"
			var body = Expression.AndAlso(left, right);

			return Expression.Lambda<Func<T, bool>>(body, parameter);
		}
	}

	// Clase para reemplazar parámetros en expresiones
	public class ReplaceParameterVisitor : ExpressionVisitor
	{
		private readonly ParameterExpression _oldParameter;
		private readonly ParameterExpression _newParameter;

		public ReplaceParameterVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
		{
			_oldParameter = oldParameter;
			_newParameter = newParameter;
		}

		protected override Expression VisitParameter(ParameterExpression node)
		{
			return node == _oldParameter ? _newParameter : base.VisitParameter(node);
		}
	}
}
