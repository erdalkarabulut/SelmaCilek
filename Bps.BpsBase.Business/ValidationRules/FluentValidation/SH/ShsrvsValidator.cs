using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SH;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SH
{
    public class ShsrvsValidator : AbstractValidator<SHSRVS>
    {
        #region ClientService

        #endregion ClientService

        public ShsrvsValidator()
        {
            RuleFor(p => p.BELGEN).Length(1,20).NotNull();
            RuleFor(p => p.BELTRH).NotNull();
            RuleFor(p => p.SRTLTR).NotNull();
            RuleFor(p => p.CRKODU).Length(1,25).NotNull();
            RuleFor(p => p.CRUNVN).Length(1,127).NotNull();
            RuleFor(p => p.CRADRS).Length(1,250).NotNull();
            RuleFor(p => p.CRTLFN).Length(1,30).NotNull();
            RuleFor(p => p.CRYTKL).Length(1,50).NotNull();
            RuleFor(p => p.TLPACN).Length(1,100).NotNull();
            RuleFor(p => p.SRVTUR).Length(1,25).NotNull();
            RuleFor(p => p.SRVDRM).Length(1,25).NotNull();
            RuleFor(p => p.GRNDRM).Length(1,25).NotNull();
            RuleFor(p => p.MKNDRM).Length(1,25).NotNull();
            RuleFor(p => p.SRVPRS).MaximumLength(50);
            RuleFor(p => p.URKTGR).Length(1,50).NotNull();
            RuleFor(p => p.URMODL).MaximumLength(50);
            RuleFor(p => p.URSERI).Length(1,50).NotNull();
            RuleFor(p => p.URSASI).MaximumLength(50);
            RuleFor(p => p.PRBTNM).Length(1,-1).NotNull();
            RuleFor(p => p.PRBTSP).MaximumLength(-1);
            RuleFor(p => p.AKSYON).MaximumLength(-1);
            RuleFor(p => p.ONYLYN).MaximumLength(100);
            RuleFor(p => p.KULPRC).MaximumLength(-1);
            RuleFor(p => p.MSIMZA).MaximumLength(-1);
            RuleFor(p => p.PRIMZA).MaximumLength(-1);
            RuleFor(p => p.STRSTP).MaximumLength(-1);
            RuleFor(p => p.PDFURL).MaximumLength(-1);
            RuleFor(p => p.CLSYNC).NotNull();
            RuleFor(p => p.SRSYNC).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
